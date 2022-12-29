using Assets.Root.Modules.UserControlSystem.Commands;
using System.Collections.Generic;

namespace Assets.Root.Modules.UserControlSystem.UI.Model
{
    public class ObjectCommandsModel
    {
        private List<Command> _commandsPool;

        public void NewCommand(ref Command command)
        {
            _commandsPool.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            _commandsPool.Remove(command);
        }
    }
}