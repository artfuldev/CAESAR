using System;
using System.Text;

namespace CAESAR.Chess.Helpers
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendEnvironmentLine(this StringBuilder stringBuilder, string value)
        {
            return stringBuilder.AppendFormat("{0}{1}", value, Environment.NewLine);
        }
    }
}