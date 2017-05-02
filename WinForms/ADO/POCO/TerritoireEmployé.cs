namespace ADO
{
    public class TerritoireEmployé
    {
        public int IdEmployé { get; set; }
        public string CodeTerritoire { get; set; }

        public override bool Equals(object obj)
        {
            bool res = false;

            if (obj is TerritoireEmployé)
            {
                TerritoireEmployé te = (TerritoireEmployé)obj;
                res = IdEmployé == te.IdEmployé && CodeTerritoire == te.CodeTerritoire;
            }

            return res;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}