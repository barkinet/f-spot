// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gnome.Vfs {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class Drive : GLib.Object {

		~Drive()
		{
			Dispose();
		}

		[Obsolete]
		protected Drive(GLib.GType gtype) : base(gtype) {}
		public Drive(IntPtr raw) : base(raw) {}

		protected Drive() : base(IntPtr.Zero)
		{
			CreateNativeObject (new string [0], new GLib.Value [0]);
		}

		delegate void VolumePreUnmountDelegate (IntPtr drive, IntPtr volume);

		static VolumePreUnmountDelegate VolumePreUnmountCallback;

		static void volumepreunmount_cb (IntPtr drive, IntPtr volume)
		{
			Drive obj = GLib.Object.GetObject (drive, false) as Drive;
			obj.OnVolumePreUnmount ((Gnome.Vfs.Volume) GLib.Object.GetObject(volume));
		}

		private static void OverrideVolumePreUnmount (GLib.GType gtype)
		{
			if (VolumePreUnmountCallback == null)
				VolumePreUnmountCallback = new VolumePreUnmountDelegate (volumepreunmount_cb);
			OverrideVirtualMethod (gtype, "volume_pre_unmount", VolumePreUnmountCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gnome.Vfs.Drive), ConnectionMethod="OverrideVolumePreUnmount")]
		protected virtual void OnVolumePreUnmount (Gnome.Vfs.Volume volume)
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (2);
			GLib.Value[] vals = new GLib.Value [2];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			vals [1] = new GLib.Value (volume);
			inst_and_params.Append (vals [1]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
		}

		[GLib.Signal("volume_pre_unmount")]
		public event Gnome.Vfs.VolumePreUnmountHandler VolumePreUnmount {
			add {
				if (value.Method.GetCustomAttributes(typeof(GLib.ConnectBeforeAttribute), false).Length > 0) {
					if (BeforeHandlers["volume_pre_unmount"] == null)
						BeforeSignals["volume_pre_unmount"] = new Gnome.VfsSharp.voidObjectObjectSignal(this, "volume_pre_unmount", value, typeof (Gnome.Vfs.VolumePreUnmountArgs), 0);					else
						((GLib.SignalCallback) BeforeSignals ["volume_pre_unmount"]).AddDelegate (value);
					BeforeHandlers.AddHandler("volume_pre_unmount", value);
				} else {
					if (AfterHandlers["volume_pre_unmount"] == null)
						AfterSignals["volume_pre_unmount"] = new Gnome.VfsSharp.voidObjectObjectSignal(this, "volume_pre_unmount", value, typeof (Gnome.Vfs.VolumePreUnmountArgs), 1);					else
						((GLib.SignalCallback) AfterSignals ["volume_pre_unmount"]).AddDelegate (value);
					AfterHandlers.AddHandler("volume_pre_unmount", value);
				}
			}
			remove {
				System.ComponentModel.EventHandlerList event_list = AfterHandlers;
				Hashtable signals = AfterSignals;
				if (value.Method.GetCustomAttributes(typeof(GLib.ConnectBeforeAttribute), false).Length > 0) {
					event_list = BeforeHandlers;
					signals = BeforeSignals;
				}
				GLib.SignalCallback cb = signals ["volume_pre_unmount"] as GLib.SignalCallback;
				event_list.RemoveHandler("volume_pre_unmount", value);
				if (cb == null)
					return;

				cb.RemoveDelegate (value);

				if (event_list["volume_pre_unmount"] == null) {
					signals.Remove("volume_pre_unmount");
					cb.Dispose ();
				}
			}
		}

		delegate void VolumeUnmountedDelegate (IntPtr drive, IntPtr volume);

		static VolumeUnmountedDelegate VolumeUnmountedCallback;

		static void volumeunmounted_cb (IntPtr drive, IntPtr volume)
		{
			Drive obj = GLib.Object.GetObject (drive, false) as Drive;
			obj.OnVolumeUnmounted ((Gnome.Vfs.Volume) GLib.Object.GetObject(volume));
		}

		private static void OverrideVolumeUnmounted (GLib.GType gtype)
		{
			if (VolumeUnmountedCallback == null)
				VolumeUnmountedCallback = new VolumeUnmountedDelegate (volumeunmounted_cb);
			OverrideVirtualMethod (gtype, "volume_unmounted", VolumeUnmountedCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gnome.Vfs.Drive), ConnectionMethod="OverrideVolumeUnmounted")]
		protected virtual void OnVolumeUnmounted (Gnome.Vfs.Volume volume)
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (2);
			GLib.Value[] vals = new GLib.Value [2];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			vals [1] = new GLib.Value (volume);
			inst_and_params.Append (vals [1]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
		}

		[GLib.Signal("volume_unmounted")]
		public event Gnome.Vfs.VolumeUnmountedHandler VolumeUnmounted {
			add {
				if (value.Method.GetCustomAttributes(typeof(GLib.ConnectBeforeAttribute), false).Length > 0) {
					if (BeforeHandlers["volume_unmounted"] == null)
						BeforeSignals["volume_unmounted"] = new Gnome.VfsSharp.voidObjectObjectSignal(this, "volume_unmounted", value, typeof (Gnome.Vfs.VolumeUnmountedArgs), 0);					else
						((GLib.SignalCallback) BeforeSignals ["volume_unmounted"]).AddDelegate (value);
					BeforeHandlers.AddHandler("volume_unmounted", value);
				} else {
					if (AfterHandlers["volume_unmounted"] == null)
						AfterSignals["volume_unmounted"] = new Gnome.VfsSharp.voidObjectObjectSignal(this, "volume_unmounted", value, typeof (Gnome.Vfs.VolumeUnmountedArgs), 1);					else
						((GLib.SignalCallback) AfterSignals ["volume_unmounted"]).AddDelegate (value);
					AfterHandlers.AddHandler("volume_unmounted", value);
				}
			}
			remove {
				System.ComponentModel.EventHandlerList event_list = AfterHandlers;
				Hashtable signals = AfterSignals;
				if (value.Method.GetCustomAttributes(typeof(GLib.ConnectBeforeAttribute), false).Length > 0) {
					event_list = BeforeHandlers;
					signals = BeforeSignals;
				}
				GLib.SignalCallback cb = signals ["volume_unmounted"] as GLib.SignalCallback;
				event_list.RemoveHandler("volume_unmounted", value);
				if (cb == null)
					return;

				cb.RemoveDelegate (value);

				if (event_list["volume_unmounted"] == null) {
					signals.Remove("volume_unmounted");
					cb.Dispose ();
				}
			}
		}

		delegate void VolumeMountedDelegate (IntPtr drive, IntPtr volume);

		static VolumeMountedDelegate VolumeMountedCallback;

		static void volumemounted_cb (IntPtr drive, IntPtr volume)
		{
			Drive obj = GLib.Object.GetObject (drive, false) as Drive;
			obj.OnVolumeMounted ((Gnome.Vfs.Volume) GLib.Object.GetObject(volume));
		}

		private static void OverrideVolumeMounted (GLib.GType gtype)
		{
			if (VolumeMountedCallback == null)
				VolumeMountedCallback = new VolumeMountedDelegate (volumemounted_cb);
			OverrideVirtualMethod (gtype, "volume_mounted", VolumeMountedCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gnome.Vfs.Drive), ConnectionMethod="OverrideVolumeMounted")]
		protected virtual void OnVolumeMounted (Gnome.Vfs.Volume volume)
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (2);
			GLib.Value[] vals = new GLib.Value [2];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			vals [1] = new GLib.Value (volume);
			inst_and_params.Append (vals [1]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
		}

		[GLib.Signal("volume_mounted")]
		public event Gnome.Vfs.VolumeMountedHandler VolumeMounted {
			add {
				if (value.Method.GetCustomAttributes(typeof(GLib.ConnectBeforeAttribute), false).Length > 0) {
					if (BeforeHandlers["volume_mounted"] == null)
						BeforeSignals["volume_mounted"] = new Gnome.VfsSharp.voidObjectObjectSignal(this, "volume_mounted", value, typeof (Gnome.Vfs.VolumeMountedArgs), 0);					else
						((GLib.SignalCallback) BeforeSignals ["volume_mounted"]).AddDelegate (value);
					BeforeHandlers.AddHandler("volume_mounted", value);
				} else {
					if (AfterHandlers["volume_mounted"] == null)
						AfterSignals["volume_mounted"] = new Gnome.VfsSharp.voidObjectObjectSignal(this, "volume_mounted", value, typeof (Gnome.Vfs.VolumeMountedArgs), 1);					else
						((GLib.SignalCallback) AfterSignals ["volume_mounted"]).AddDelegate (value);
					AfterHandlers.AddHandler("volume_mounted", value);
				}
			}
			remove {
				System.ComponentModel.EventHandlerList event_list = AfterHandlers;
				Hashtable signals = AfterSignals;
				if (value.Method.GetCustomAttributes(typeof(GLib.ConnectBeforeAttribute), false).Length > 0) {
					event_list = BeforeHandlers;
					signals = BeforeSignals;
				}
				GLib.SignalCallback cb = signals ["volume_mounted"] as GLib.SignalCallback;
				event_list.RemoveHandler("volume_mounted", value);
				if (cb == null)
					return;

				cb.RemoveDelegate (value);

				if (event_list["volume_mounted"] == null) {
					signals.Remove("volume_mounted");
					cb.Dispose ();
				}
			}
		}

		[DllImport("gnomevfs-2")]
		static extern UIntPtr gnome_vfs_drive_get_id(IntPtr raw);

		public ulong Id { 
			get {
				UIntPtr raw_ret = gnome_vfs_drive_get_id(Handle);
				ulong ret = (ulong) raw_ret;
				return ret;
			}
		}

		[DllImport("gnomevfs-2")]
		static extern IntPtr gnome_vfs_drive_get_display_name(IntPtr raw);

		public string DisplayName { 
			get {
				IntPtr raw_ret = gnome_vfs_drive_get_display_name(Handle);
				string ret = GLib.Marshaller.PtrToStringGFree(raw_ret);
				return ret;
			}
		}

		[DllImport("gnomevfs-2")]
		static extern IntPtr gnome_vfs_drive_get_icon(IntPtr raw);

		public string Icon { 
			get {
				IntPtr raw_ret = gnome_vfs_drive_get_icon(Handle);
				string ret = GLib.Marshaller.PtrToStringGFree(raw_ret);
				return ret;
			}
		}

		[DllImport("gnomevfs-2")]
		static extern bool gnome_vfs_drive_is_mounted(IntPtr raw);

		public bool IsMounted { 
			get {
				bool raw_ret = gnome_vfs_drive_is_mounted(Handle);
				bool ret = raw_ret;
				return ret;
			}
		}

		[DllImport("gnomevfs-2")]
		static extern IntPtr gnome_vfs_drive_get_activation_uri(IntPtr raw);

		public string ActivationUri { 
			get {
				IntPtr raw_ret = gnome_vfs_drive_get_activation_uri(Handle);
				string ret = GLib.Marshaller.PtrToStringGFree(raw_ret);
				return ret;
			}
		}

		[DllImport("gnomevfs-2")]
		static extern IntPtr gnome_vfs_drive_get_device_path(IntPtr raw);

		public string DevicePath { 
			get {
				IntPtr raw_ret = gnome_vfs_drive_get_device_path(Handle);
				string ret = GLib.Marshaller.PtrToStringGFree(raw_ret);
				return ret;
			}
		}

		[DllImport("gnomevfs-2")]
		static extern IntPtr gnome_vfs_drive_get_mounted_volume(IntPtr raw);

		public Gnome.Vfs.Volume MountedVolume { 
			get {
				IntPtr raw_ret = gnome_vfs_drive_get_mounted_volume(Handle);
				Gnome.Vfs.Volume ret;
				if (raw_ret == IntPtr.Zero)
					ret = null;
				else
					ret = (Gnome.Vfs.Volume) GLib.Object.GetObject(raw_ret);
				return ret;
			}
		}

		[DllImport("gnomevfs-2")]
		static extern int gnome_vfs_drive_compare(IntPtr raw, IntPtr b);

		public int Compare(Gnome.Vfs.Drive b) {
			int raw_ret = gnome_vfs_drive_compare(Handle, b.Handle);
			int ret = raw_ret;
			return ret;
		}

		[DllImport("gnomevfs-2")]
		static extern bool gnome_vfs_drive_is_connected(IntPtr raw);

		public bool IsConnected { 
			get {
				bool raw_ret = gnome_vfs_drive_is_connected(Handle);
				bool ret = raw_ret;
				return ret;
			}
		}

		[DllImport("gnomevfs-2")]
		static extern bool gnome_vfs_drive_is_user_visible(IntPtr raw);

		public bool IsUserVisible { 
			get {
				bool raw_ret = gnome_vfs_drive_is_user_visible(Handle);
				bool ret = raw_ret;
				return ret;
			}
		}

		[DllImport("gnomevfs-2")]
		static extern int gnome_vfs_drive_get_device_type(IntPtr raw);

		public Gnome.Vfs.DeviceType DeviceType { 
			get {
				int raw_ret = gnome_vfs_drive_get_device_type(Handle);
				Gnome.Vfs.DeviceType ret = (Gnome.Vfs.DeviceType) raw_ret;
				return ret;
			}
		}

		[DllImport("gnomevfs-2")]
		static extern IntPtr gnome_vfs_drive_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = gnome_vfs_drive_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}


		static Drive ()
		{
			GtkSharp.GnomeVfsSharp.ObjectManager.Initialize ();
		}
#endregion
	}
}
