namespace TestPouet
{
    internal class ContexteBis
    {
        public Employé Employé { get; set; }
        public ContexteBis()
        {
            Employé = DAL.GetEmployé();
            DAL.GetProperty("toto");
        }
    }
}