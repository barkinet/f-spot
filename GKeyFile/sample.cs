/*
 * sampple.cs : some code using GKeyFile
 *
 * Author(s):
 *	Stephane Delcroix  (stephane@delcroix.org)
 *
 * Copyright (c) 2008 Novell, Inc.
 *
 * 
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
 * LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 *
 */
using System;
using KeyFile;

public class TestGKeyFile
{
	static void Main ()
	{
		GKeyFile key_file = new GKeyFile ();
		key_file.SetComment (null, null, String.Format ("This file was autogenerated by sample.cs on {0}", DateTime.Now));
		key_file.SetString ("General", "sKey0", "that's the string value associated to the sKey0");
		key_file.SetComment ("General", null, "A comment for the General group");
		key_file.SetComment ("General", "sKey0", "A comment for the sKey0 key");
		key_file.SetStringList ("Lists", "sList", new string [] {"item0", "item1", "item2", "lastitem"});
		key_file.SetBoolean ("SingleValues", "aBool", true);
		key_file.SetBoolean ("SingleValues", "anotherBool", false);
		key_file.SetString ("SingleValues", "aString", "this is _not_ a string");
		key_file.SetInteger ("SingleValues", "anInt", 42);
		key_file.SetDouble ("SingleValues", "aDouble", Math.PI);
		key_file.SetComment ("SingleValues", "aDouble", "Change this at the time the square became the new circle");
		key_file.Save ("mysamplefile.ini");

		key_file = new GKeyFile ("mysamplefile.ini");
		key_file.RemoveComment ("SingleValues", "aDouble");
		key_file.SetBooleanList ("Lists", "bools", new bool [] {true, false, false, true});
		key_file.SetIntegerList ("Lists", "ints", new int [] {0, 1, 2, -3, -5});
		key_file.SetDoubleList ("Lists", "doubles", new double [] {Math.PI, Math.Sqrt (2)});

		foreach (string group in key_file.GetGroups()) {
			Console.WriteLine ("\t"+group);
			foreach (string key in key_file.GetKeys (group))
				Console.WriteLine ("\t\t"+ key);
		}
		Console.WriteLine (key_file.HasGroup ("Foo"));
		Console.WriteLine (key_file.HasGroup ("General"));
		Console.WriteLine (key_file.HasKey ("General", "sKey0"));
		Console.WriteLine (key_file.HasKey ("General", "sKey1"));
		try {
			key_file.GetValue ("foo", "bar");
		} catch (GLib.GException e) {
			Console.WriteLine (e);
		}
		foreach (string val in key_file.GetStringList ("Lists", "sList"))
			Console.WriteLine (val);

		foreach (int i in key_file.GetIntegerList ("Lists", "ints"))
			Console.WriteLine (i);

		key_file.Save ("mysamplefile2.ini");

		key_file = new GKeyFile ("mysamplefile.ini");
		key_file.RemoveGroup ("General");
		key_file.Save ("mysamplefile3.ini");

	}
}
