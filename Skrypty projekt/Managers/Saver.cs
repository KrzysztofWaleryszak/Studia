using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;


public class Saver
{
	int[] tab;
	public Saver(int length)
	{
		tab = new int[length + 1];
	}

	public void Save()
	{
		using (BinaryWriter bw = new BinaryWriter(new FileStream("points.mo", FileMode.Create, FileAccess.Write, FileShare.Read)))
		{
			for (int i = 1; i < tab.Length; i++)
			{
				bw.Write(tab[i]);
			}
			Console.WriteLine();
		}

	}
	public void Add(int var)
	{
		tab[0] = var;
		Array.Sort(tab);
	}

	public void Read()
	{
		FileInfo fi = new FileInfo("points.mo");
		if (fi.Exists)
		{
			using (BinaryReader br = new BinaryReader(fi.OpenRead()))
			{
				try
				{
					for (int i = 1; i < tab.Length; i++)
					{
						tab[i] = br.ReadInt32();
					}
				}
				catch (Exception)
				{

				}
			}
		}
	}

	public int[] ReadTab()
	{
		Read();
		int[] result = new int[tab.Length - 1];
		Array.Copy(tab,1,result,0,tab.Length-1);
		return result;
	}
}