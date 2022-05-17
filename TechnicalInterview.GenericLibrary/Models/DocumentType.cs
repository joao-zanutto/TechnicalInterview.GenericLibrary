using System.Runtime.Serialization;

namespace TechnicalInterview.GenericLibrary.Models
{
    public enum DocumentType
    {
        [EnumMember]
        NoSupport = '0',
        [EnumMember]
        CNPJ = '1',
        [EnumMember]
        CPF = '2'

    }
}
