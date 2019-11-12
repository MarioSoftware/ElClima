using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.Authorization.IdentityHelper
{

    public static class Handler
    {
        static Dictionary<string, string> errorMessages = new Dictionary<string, string> {
             {"IdentityError","Ha ocurrido un error."},
               {"ConcurrencyFailure","Ha ocurrido un error, el objeto ya ha sido modificado (Optimistic concurrency failure)." },
               {"PasswordMismatch" , "Password Incorrecta."  },
               {"InvalidToken" ,"Ha ingresado un código Inválido."  },
               {"LoginAlreadyAssociated" ,"Un usuario con ese nombre ya existe."  },
               {"InvalidUserName" ,"El nombre de usuario es inválido. Solo puede contener letras y números."  },
               {"InvalidEmail","La dirección de email es incorrecta."  },
               {"DuplicateUserName" ,"El usuario ya existe, por favor ingrese un nombre diferente."  },
               {"DuplicateEmail" ,"La direccion de email ya se encuentra registrada. Puede recupar su contraseña para ingresar nuevamente al sistema." },
               {"InvalidRoleName" ,"El nombre de rol es inválido."  },
               {"DuplicateRoleName","El nombre de rol ya existe."  },
               {"UserAlreadyHasPassword" ,"El usuario ya tiene contraseña."  },
               {"UserLockoutNotEnabled","El bloqueo no esta habilitado para este usuario."  },
               {"UserAlreadyInRole","El usuario ya es parte del rol."  },
               {"UserNotInRole" ,"El usuario no es parte del rol. " },
               {"PasswordTooShort","La contraseña es demasiado corta."  },
               {"PasswordRequiresNonAlphanumeric","La contraseña debe contener al menos un caracter no alfanumérico." },
               {"PasswordRequiresDigit","La contraseña debe incluir al menos un dígito ('0'-'9')."  },
               {"PasswordRequiresLower","La contraseña debe incluir al menos una letra minúscula ('a'-'z')." },
               {"PasswordRequiresUpper" ,"La contraseña debe incluir al menos una letra MAYÚSCULA ('A'-'Z')." }
        }; 

        public static string GetErrorMessages(string key)
        {
            return errorMessages.ContainsKey(key) ? errorMessages[key] : "";
        } 
    }
}
