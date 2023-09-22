namespace BankSystem.Model
{
    public class Consultant : BankWorker
    {
        public override string Name => "Consultant";

        internal override bool CanWritePhone => true;
    }
}
