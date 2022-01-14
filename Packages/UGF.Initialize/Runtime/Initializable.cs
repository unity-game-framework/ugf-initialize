using System;

namespace UGF.Initialize.Runtime
{
    public class Initializable : InitializeBase
    {
        public IInitializeCollection Children { get; }

        public Initializable() : this(new InitializeCollection<IInitialize>())
        {
        }

        public Initializable(IInitializeCollection children)
        {
            Children = children ?? throw new ArgumentNullException(nameof(children));
        }

        protected override void OnPreInitialize()
        {
            base.OnPreInitialize();

            Children.Initialize();
        }

        protected override void OnPostUninitialize()
        {
            base.OnPostUninitialize();

            Children.Uninitialize();
        }
    }
}
