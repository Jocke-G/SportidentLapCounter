using System;
using System.Linq;
using System.Windows.Forms;

namespace SportidentLapCounter.Helpers
{
    public static class PasteHelper
    {
        private static readonly char[] RowDelimiter = { '\n', '\r' };  // Cr and Lf.
        private const char ColumnDelimiter = '\t'; // Tab.


        public static string[] SplitClipboardToRows()
        {
            var dataInClipboard = Clipboard.GetDataObject();
            if (dataInClipboard == null)
                return null;

            var textInClipboard = dataInClipboard.GetData(DataFormats.Text);
            if (textInClipboard == null)
                return null;

            var stringInClipboard = textInClipboard.ToString();

            var rowsInClipboard = stringInClipboard.Split(RowDelimiter, StringSplitOptions.RemoveEmptyEntries);
            return rowsInClipboard;
        }

        public static string[] SplitExcellRowToArray(string row, int prefferedLength)
        {
            var valuesInRow = row.Split(ColumnDelimiter);
            if (row.Length < prefferedLength)
                return null;

            while (valuesInRow.Length > prefferedLength && valuesInRow.First() == string.Empty)
            {
                valuesInRow = valuesInRow.Skip(1).ToArray();
            }
            return valuesInRow;
        }
    }
}
