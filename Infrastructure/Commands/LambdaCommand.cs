using Journey.Infrastructure.Commands.Base;
using System;

namespace Journey.Infrastructure.Commands
{
    public class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _Execute = execute ?? throw new ArgumentException(nameof(Execute));
            _CanExecute = canExecute;
        }

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;
        public override void Execute(object parameter) => _Execute(parameter);
      
    }
}