using System;

namespace Momiji
{
	public class SQLResult
	{
		private int UpperCount;
		private int LowerCount;
		private string[,] data;
		private bool success = false;
		public string error = "";

		// I *COULD* create another getCell to return as int.. But c# doesn't allow that
		// And instead of copying code... I just call the getCell function and convert it to INT.
		// TODO // Optimize this!
		public int getCellInt (string ColumnName, int row)
		{
			string value = this.getCell (ColumnName, row);
			int ret;
			if (String.Compare (value, "true", true) == 0)
				ret = 1;
			else if (!int.TryParse (value, out ret))
				ret = 0;
			return ret;
		}

		public string getCell (string ColumnName, int row)
		{
			int i = 0;
			int column_index = -1;
			for (i = 0; i < this.GetNumberOfColumns (); i++) {
				if (this.GetColumnName (i) == ColumnName)
					column_index = i;
			}

			if (column_index != -1)
				return this.data [row + 1, column_index];
			else
				return "";
		}

		public SQLResult (string[,] data, int upper, int lower, bool success)
		{
			this.data = data;
			this.UpperCount = upper;
			this.LowerCount = lower;
			this.success = success;
		}

		public string GetColumnName (int index)
		{
			return data [0, index];
		}

		public string[] GetColumnNames ()
		{
			string[] columns = new string[LowerCount];
			int i = 0;
			for (i = 0; i < this.LowerCount; i++) {
				columns [i] = data [0, i];
			}
			return columns;
		}

		public int GetNumberOfColumns ()
		{
			return this.LowerCount;
		}

		public bool successful ()
		{
			return this.success;
		}

		public int GetNumberOfRows ()
		{
			return this.UpperCount - 1;
		}
	}
}
