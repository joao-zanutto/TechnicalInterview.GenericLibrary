using TechnicalInterview.GenericLibrary.Contracts;
using TechnicalInterview.GenericLibrary.Models;

namespace TechnicalInterview.GenericLibrary.Services
{
    /// <summary>
    /// Do validations for CPF and CNPJ
    /// </summary>
    public class DocumentValidator:IDocumentValidator
    {
        public DocumentType AutoSelector(string input)
        {
            if (IsCPF(input))
                return DocumentType.CPF;
            if (IsCNPJ(input))
                return DocumentType.CNPJ;
            else
                return DocumentType.NoSupport;
        }

        public bool IsCPF(string input)
        {
            int[] firstMultiplier = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] secondMultiplier = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string hasCpf;
            string digit;
            int addition;
            int remainder;
            input = input.Trim();
            input = input.Replace(".", "").Replace("-", "").Replace("/", "").Replace(@"\", "");
            if (input.Length != 11)
                return false;
            hasCpf = input.Substring(0, 9);
            addition = 0;

            for (int i = 0; i < 9; i++)
                addition += int.Parse(hasCpf[i].ToString()) * firstMultiplier[i];
            remainder = addition % 11;
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;
            digit = remainder.ToString();
            hasCpf = hasCpf + digit;
            addition = 0;
            for (int i = 0; i < 10; i++)
                addition += int.Parse(hasCpf[i].ToString()) * secondMultiplier[i];
            remainder = addition % 11;
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;
            digit = digit + remainder.ToString();
            return input.EndsWith(digit);
        }
        
        public bool IsCNPJ(string input)
        {
            int[] firstMultiplier = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] secondMultiplier = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            string hasCNPJ;
            string digit;
            int addition;
            int remainder;

            input = input.Trim();
            input = input.Replace(".", "").Replace("-", "").Replace("/", "");
            if (input.Length != 14)
                return false;
            hasCNPJ = input.Substring(0, 12);
            addition = 0;
            for (int i = 0; i < 12; i++)
                addition += int.Parse(hasCNPJ[i].ToString()) * firstMultiplier[i];
            remainder = (addition % 11);
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;
            digit = remainder.ToString();
            hasCNPJ = hasCNPJ + digit;
            addition = 0;
            for (int i = 0; i < 13; i++)
                addition += int.Parse(hasCNPJ[i].ToString()) * secondMultiplier[i];
            remainder = (addition % 11);
            if (remainder < 2)
                remainder = 0;
            else
                remainder = 11 - remainder;
            digit = digit + remainder.ToString();
            return input.EndsWith(digit);
        }

    }
}
