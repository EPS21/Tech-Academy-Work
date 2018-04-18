using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.Domain.Exceptions
{
    public class CharacterAlreadyDeadException : Exception // This inherits from Exception class
    {
        public string CharacterName { get; set; }

        public CharacterAlreadyDeadException(string characterName)
        {
            CharacterName = characterName;
        }
    }
}
