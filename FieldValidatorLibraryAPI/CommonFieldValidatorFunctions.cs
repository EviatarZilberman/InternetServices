namespace FieldValidatorLibraryAPI
{
    public class CommonFieldValidatorFunctions
    {
        public delegate bool RequiredValidDel(string fieldVal);
        public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
        public delegate bool DataValidDel(string fieldVal, out DateTime validDateTime);
        public delegate bool PatternMatchDel(string fieldVal, string pattern);
        public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);



    }
}
