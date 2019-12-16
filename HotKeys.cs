// linespaceDeleter.HotKeys
using linespaceDeleter;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class HotKeys
{
	public delegate void HotKeyCallBackHanlder();

	public enum HotkeyModifiers
	{
		Alt = 1,
		Control = 2,
		Shift = 4,
		Win = 8
	}

	private int keyid = 10;

	private Dictionary<int, HotKeyCallBackHanlder> keymap = new Dictionary<int, HotKeyCallBackHanlder>();

	[DllImport("user32.dll")]
	private static extern bool RegisterHotKey(IntPtr hWnd, int id, int modifiers, Keys vk);

	[DllImport("user32.dll")]
	private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

	public void Regist(IntPtr hWnd, int modifiers, Keys vk, HotKeyCallBackHanlder callBack)
	{
		int num = keyid++;
		if (!RegisterHotKey(hWnd, num, modifiers, vk))
		{
			throw new Exception("注册失败！");
		}
		keymap[num] = callBack;
	}

	public void UnRegist(IntPtr hWnd, HotKeyCallBackHanlder callBack)
	{
		foreach (KeyValuePair<int, HotKeyCallBackHanlder> item in keymap)
		{
			if (item.Value == callBack)
			{
				UnregisterHotKey(hWnd, item.Key);
				break;
			}
		}
	}

	public void ProcessHotKey(Message m)
	{
		if (m.Msg == 786)
		{
			int key = m.WParam.ToInt32();
			if (keymap.TryGetValue(key, out HotKeyCallBackHanlder value))
			{
				value();
			}
		}
	}
}
