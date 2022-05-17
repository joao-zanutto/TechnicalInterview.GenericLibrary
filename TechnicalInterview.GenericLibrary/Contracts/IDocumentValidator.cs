using TechnicalInterview.GenericLibrary.Models;

namespace TechnicalInterview.GenericLibrary.Contracts
{
    public interface IDocumentValidator
    {
        /// <summary>
        /// This auto select the kind of document between IsCPF and IsCNPJ
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>The kind of document</returns>
        DocumentType AutoSelector(string input);
        /// <summary>
        /// Enter a string to validates if there is a CPF
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>A boolean. When true, is a valid CPF</returns>
        bool IsCPF(string input);

        /// <summary>
        /// Enter a string to validates if there is a CNPJ
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>A boolean. When true, is a valid CNPJ</returns>
        bool IsCNPJ(string input);
    }
}
