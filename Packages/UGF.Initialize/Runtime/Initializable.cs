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

        protected override void OnInitialize()
        {
            base.OnInitialize();

            Children.Initialize();
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Children.Uninitialize();
        }
    }
}
