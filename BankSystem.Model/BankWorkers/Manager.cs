namespace BankSystem.Model
{
    public class Manager : BankWorker
    {
        public override string Name => "Manager";

        internal override bool CanWriteLastName => true;

        internal override bool CanWriteFirstName => true;

        internal override bool CanWritePatronymic => true;

        internal override bool CanWritePhone => true;

        internal override bool CanWritePassport => true;
        internal override bool CanReadPassport => true;

        public override bool СanAddNewClient => true;
        public override bool СanRemoveClient => true;
    }
}
