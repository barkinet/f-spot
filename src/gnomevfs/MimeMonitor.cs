// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gnome.Vfs {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class MimeMonitor : GLib.Object {

		~MimeMonitor()
		{
			Dispose();
		}

		[Obsolete]
		protected MimeMonitor(GLib.GType gtype) : base(gtype) {}
		public MimeMonitor(IntPtr raw) : base(raw) {}

		protected MimeMonitor() : base(IntPtr.Zero)
		{
			CreateNativeObject (new string [0], new GLib.Value [0]);
		}

		delegate void DataChangedDelegate (IntPtr monitor);

		static DataChangedDelegate DataChangedCallback;

		static void datachanged_cb (IntPtr monitor)
		{
			MimeMonitor obj = GLib.Object.GetObject (monitor, false) as MimeMonitor;
			obj.OnDataChanged ();
		}

		private static void OverrideDataChanged (GLib.GType gtype)
		{
			if (DataChangedCallback == null)
				DataChangedCallback = new DataChangedDelegate (datachanged_cb);
			OverrideVirtualMethod (gtype, "data_changed", DataChangedCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gnome.Vfs.MimeMonitor), ConnectionMethod="OverrideDataChanged")]
		protected virtual void OnDataChanged ()
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (1);
			GLib.Value[] vals = new GLib.Value [1];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
		}

		[GLib.Signal("data_changed")]
		public event System.EventHandler DataChanged {
			add {
				if (value.Method.GetCustomAttributes(typeof(GLib.ConnectBeforeAttribute), false).Length > 0) {
					if (BeforeHandlers["data_changed"] == null)
						BeforeSignals["data_changed"] = new Gnome.VfsSharp.voidObjectSignal(this, "data_changed", value, typeof (System.EventArgs), 0);					else
						((GLib.SignalCallback) BeforeSignals ["data_changed"]).AddDelegate (value);
					BeforeHandlers.AddHandler("data_changed", value);
				} else {
					if (AfterHandlers["data_changed"] == null)
						AfterSignals["data_changed"] = new Gnome.VfsSharp.voidObjectSignal(this, "data_changed", value, typeof (System.EventArgs), 1);					else
						((GLib.SignalCallback) AfterSignals ["data_changed"]).AddDelegate (value);
					AfterHandlers.AddHandler("data_changed", value);
				}
			}
			remove {
				System.ComponentModel.EventHandlerList event_list = AfterHandlers;
				Hashtable signals = AfterSignals;
				if (value.Method.GetCustomAttributes(typeof(GLib.ConnectBeforeAttribute), false).Length > 0) {
					event_list = BeforeHandlers;
					signals = BeforeSignals;
				}
				GLib.SignalCallback cb = signals ["data_changed"] as GLib.SignalCallback;
				event_list.RemoveHandler("data_changed", value);
				if (cb == null)
					return;

				cb.RemoveDelegate (value);

				if (event_list["data_changed"] == null) {
					signals.Remove("data_changed");
					cb.Dispose ();
				}
			}
		}

		[DllImport("gnomevfs-2")]
		static extern IntPtr gnome_vfs_mime_monitor_get();

		public static Gnome.Vfs.MimeMonitor Get() {
			IntPtr raw_ret = gnome_vfs_mime_monitor_get();
			Gnome.Vfs.MimeMonitor ret;
			if (raw_ret == IntPtr.Zero)
				ret = null;
			else
				ret = (Gnome.Vfs.MimeMonitor) GLib.Object.GetObject(raw_ret);
			return ret;
		}

		[DllImport("gnomevfs-2")]
		static extern IntPtr gnome_vfs_mime_monitor_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = gnome_vfs_mime_monitor_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}


		static MimeMonitor ()
		{
			GtkSharp.GnomeVfsSharp.ObjectManager.Initialize ();
		}
#endregion
	}
}
