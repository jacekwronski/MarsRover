
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Domain
{
    internal static class CommandsExtensionMethods
    {
        private const string LEFT = "L";
        private const string RIGHT = "R";
        private const string FORWARD = "F";
        private const string BACKWARD = "B";
        internal static List<MovementEnum> TranslateToMovementsList(this string[] commands)
        {
            List<MovementEnum> movementEnumList = new List<MovementEnum>();

            commands.ToList().ForEach(command => {
            if(command.ToUpper() == FORWARD)
                movementEnumList.Add(MovementEnum.Forward);
             if(command.ToUpper() == BACKWARD)
                movementEnumList.Add(MovementEnum.Backward);
             if(command.ToUpper() == LEFT)
                movementEnumList.Add(MovementEnum.Left);
             if(command.ToUpper() == RIGHT)
                movementEnumList.Add(MovementEnum.Right);
            });

            return movementEnumList;
        }   
    }
}