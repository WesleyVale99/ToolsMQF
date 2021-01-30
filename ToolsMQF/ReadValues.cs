using System;
using System.IO;
using System.Text;

namespace ToolsMQF
{
	public class ReadValues
	{
		public BinaryReader reader;
		public ReadValues(BinaryReader reader)
		{
			this.reader = reader;
		}
		protected internal byte ReadC() => reader.ReadByte();

		protected internal short ReadU() =>reader.ReadInt16();
		protected internal int ReadD() => reader.ReadInt32();
		protected internal long ReadQ() => reader.ReadInt64();
		protected internal byte[] ReadB(int count) => reader.ReadBytes(count);
		protected internal sbyte ReadSB() => reader.ReadSByte();
		protected internal ushort ReadUH() => reader.ReadUInt16();
		protected internal uint ReadUD() => reader.ReadUInt32();
		protected internal float ReadF() => reader.ReadSingle();
		protected internal ulong ReadUQ() => reader.ReadUInt64();
		protected internal string ReadS(int size)
		{
			string texto = Encoding.GetEncoding(1251).GetString(ReadB(size));
			int length = texto.IndexOf('\0');
			bool flag = length != -1;
			if (flag)
			{
				texto = texto.Substring(0, length);
			}
			return texto;
		}
		protected internal string strings(byte[] ddr, int offset, int size)
		{
			string texto = Encoding.GetEncoding(1251).GetString(ddr, offset, size);
			int length = texto.IndexOf('\0');
			bool flag = length != -1;
			if (flag)
			{
				texto = texto.Substring(0, length);
			}
			return texto;
		}
		protected internal string Vector(int count)
		{
			string vector = "";
			for (int i = 0; i < count; i++)
			{
				vector = vector + this.ReadF().ToString() + "\n";
			}
			return vector;
		}

	}
}
