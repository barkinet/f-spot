using Gtk;
using GtkSharp;
using System;
using System.Text;
using System.Collections;

public class TagCommands {

	public enum TagType {
		Tag,
		Category
	}

	public class Create {
		TagStore tag_store;
		Gtk.Window parent_window;

		[Glade.Widget]
		private Dialog create_tag_dialog;

		[Glade.Widget]
		private Button ok_button;

		[Glade.Widget]
		private Entry tag_name_entry;

		[Glade.Widget]
		private Label prompt_label;

		[Glade.Widget]
		private Label already_in_use_label;

		[Glade.Widget]
		private OptionMenu category_option_menu;

		private ArrayList categories;

		private void PopulateCategories (ArrayList categories, Category parent)
		{
			foreach (Tag tag in parent.Children) {
				if (tag is Category) {
					categories.Add (tag);
					PopulateCategories (categories, tag as Category);
				}
			}
		}

		private void PopulateCategoryOptionMenu ()
		{
			categories = new ArrayList ();
			PopulateCategories (categories, tag_store.RootCategory);

			Menu menu = new Menu ();

			if (categories.Count == 0) {
				MenuItem item = new MenuItem ("(No categories)");
				category_option_menu.Sensitive = false;
				menu.Append (item);
			} else {
				foreach (Category category in categories) {
					StringBuilder label_builder = new StringBuilder ();

					for (Category parent = category.Category; 
					     parent != tag_store.RootCategory; 
					     parent = parent.Category)
						label_builder.Append ("  ");

					label_builder.Append (category.Name);

					// FIXME escape underscores.
					MenuItem item = new MenuItem (label_builder.ToString ());
					menu.Append (item);
				}

				category_option_menu.Sensitive = true;
			}

			menu.ShowAll ();
			category_option_menu.Menu = menu;
		}

		private bool TagNameExistsInCategory (string name, Category category)
		{
			foreach (Tag tag in category.Children) {
				if (tag.Name == name)
					return true;

				if (tag is Category && TagNameExistsInCategory (name, tag as Category))
					return true;
			}

			return false;
		}

		private void Update ()
		{
			if (tag_name_entry.Text == "") {
				ok_button.Sensitive = false;
				already_in_use_label.Markup = "";
			} else if (TagNameExistsInCategory (tag_name_entry.Text, tag_store.RootCategory)) {
				ok_button.Sensitive = false;
				already_in_use_label.Markup = "<small>This name is already in use</small>";
			} else {
				ok_button.Sensitive = true;
				already_in_use_label.Markup = "";
			}
		}

		private void HandleTagNameEntryChanged (object sender, EventArgs args)
		{
			Update ();
		}

		public bool Execute (TagType type)
		{
			Glade.XML xml = new Glade.XML (null, "f-spot.glade", "create_tag_dialog", null);
			xml.Autoconnect (this);

			create_tag_dialog.DefaultResponse = ResponseType.Ok;

			switch (type) {
			case TagType.Tag:
				create_tag_dialog.Title = "Create New Tag";
				prompt_label.Text = "Name of new tag:";
				break;
			case TagType.Category:
				create_tag_dialog.Title = "Create New Category";
				prompt_label.Text = "Name of new category:";
				break;
			}

			PopulateCategoryOptionMenu ();
			Update ();

			ResponseType response = (ResponseType) create_tag_dialog.Run ();

			bool success = false;

			if (response == ResponseType.Ok) {
				try {
					Category parent_category;

					if (categories.Count == 0)
						parent_category = tag_store.RootCategory;
					else
						parent_category = categories [category_option_menu.History] as Category;

					if (type == TagType.Category)
						tag_store.CreateCategory (parent_category, tag_name_entry.Text);
					else
						tag_store.CreateTag (parent_category, tag_name_entry.Text);
					success = true;
				} catch (Exception ex) {
					// FIXME error dialog.
					Console.WriteLine ("error {0}", ex);
				}
			}

			create_tag_dialog.Destroy ();
			return success;
		}

		public Create (TagStore tag_store, Gtk.Window parent_window)
		{
			this.tag_store = tag_store;
			this.parent_window = parent_window;
		}
	}

	public class Edit {
		TagStore tag_store;
		Gtk.Window parent_window;
		Tag tag;

		[Glade.Widget]
		Dialog edit_tag_dialog;

		[Glade.Widget]
		private Button ok_button;

		[Glade.Widget]
		private Entry tag_name_entry;

		[Glade.Widget]
		private Label prompt_label;

		[Glade.Widget]
		private Label already_in_use_label;

		[Glade.Widget]
		private Gtk.Image icon_image;

		[Glade.Widget]
		private Button icon_button;
		
		[Glade.Widget]
		private OptionMenu category_option_menu;

		private ArrayList categories;

		private void HandleTagNameEntryChanged (object sender, EventArgs args)
		{
			Update ();
		}

		private bool TagNameExistsInCategory (string name, Category category)
		{
			foreach (Tag tag in category.Children) {
				if (tag.Name == name)
					return true;

				if (tag is Category && TagNameExistsInCategory (name, tag as Category))
					return true;
			}

			return false;
		}

		string orig_name;
		string last_valid_name;
		private void Update ()
		{
			string name = tag_name_entry.Text;

			if (name == "") {
				ok_button.Sensitive = false;
				already_in_use_label.Markup = "";
			} else if (TagNameExistsInCategory (name, tag_store.RootCategory)
				   && name != orig_name) {
				ok_button.Sensitive = false;
				already_in_use_label.Markup = "<small>This name is already in use</small>";
			} else {
				ok_button.Sensitive = true;
				already_in_use_label.Markup = "";
				last_valid_name = tag_name_entry.Text;
			}
		}

		private void PopulateCategories (ArrayList categories, Category parent)
		{
			foreach (Tag tag in parent.Children) {
				if (tag is Category) {
					categories.Add (tag);
					PopulateCategories (categories, tag as Category);
				}
			}
		}

		private void PopulateCategoryOptionMenu (Tag t)
		{
			int history = 0;
			int i = 0;
			categories = new ArrayList ();
			PopulateCategories (categories, tag_store.RootCategory);

			Menu menu = new Menu ();

			if (categories.Count == 0) {
				MenuItem item = new MenuItem ("(No categories)");
				category_option_menu.Sensitive = false;
				menu.Append (item);
			} else {
				foreach (Category category in categories) {
					StringBuilder label_builder = new StringBuilder ();
					
					if (t.Category == category)
						history = i;
					
					i++;

					for (Category parent = category.Category; 
					     parent != tag_store.RootCategory; 
					     parent = parent.Category)
						label_builder.Append ("  ");

					label_builder.Append (category.Name);

					// FIXME escape underscores.
					MenuItem item = new MenuItem (label_builder.ToString ());
					menu.Append (item);
				}

				category_option_menu.Sensitive = true;
			}

			menu.ShowAll ();
			category_option_menu.Menu = menu;
			category_option_menu.SetHistory ((uint)history);
		}

		public bool Execute (Tag t) 
		{
			Glade.XML xml = new Glade.XML (null, "f-spot.glade", "edit_tag_dialog", null);
			xml.Autoconnect (this);

			edit_tag_dialog.DefaultResponse = ResponseType.Ok;

			if (t is Category) {
				edit_tag_dialog.Title = "Edit Category";
				prompt_label.Text = "Category name:";
			} else {
				edit_tag_dialog.Title = "Edit Tag";
				prompt_label.Text = "Tag name:";
			}

			orig_name = last_valid_name = t.Name;
			tag_name_entry.Text = t.Name;

			icon_image.Pixbuf = t.Icon;
			PopulateCategoryOptionMenu  (t);

			category_option_menu.Changed += HandleTagNameEntryChanged;
			ResponseType response = (ResponseType) edit_tag_dialog.Run ();
			bool success = false;

			if (response == ResponseType.Ok) {
				try {
					t.Name = last_valid_name;
					t.Category = categories [category_option_menu.History] as Category;
					t.Icon = icon_image.Pixbuf;

					success = true;
				} catch (Exception ex) {
					// FIXME error dialog.
					Console.WriteLine ("error {0}", ex);
				}
			}
			
			edit_tag_dialog.Destroy ();
			return success;
		}

		public Edit (TagStore tag_store, Gtk.Window parent_window)
		{
			this.tag_store = tag_store;
			this.parent_window = parent_window;
		}
	}
}
