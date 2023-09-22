namespace BankSystem.Model
{
    public abstract class BankWorker
    {
        public abstract string Name { get;}

        internal virtual bool CanWriteLastName { get; } = false;
        internal virtual bool CanReadLastName { get; } = true;

        internal virtual bool CanWriteFirstName { get; } = false;
        internal virtual bool CanReadFirstName { get; } = true;

        internal virtual bool CanWritePatronymic { get; } = false;
        internal virtual bool CanReadPatronymic { get; } = true;

        internal virtual bool CanWritePhone { get; } = false;
        internal virtual bool CanReadPhone { get; } = true;

        internal virtual bool CanWritePassport { get; } = false;
        internal virtual bool CanReadPassport { get; } = false;

        public virtual bool СanAddNewClient { get; } = false;
        public virtual bool СanRemoveClient { get; } = false;

    }
}
