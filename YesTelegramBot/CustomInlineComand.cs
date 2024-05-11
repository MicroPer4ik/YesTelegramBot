using PRTelegramBot.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesTelegramBot
{
    [InlineCommand]
    public enum CustomInlineComand
    {
        ExampleOne = 100,
        ExampleTwo,
        ExampleThree
    }
}
