using Discord;
using Discord.Interactions;

namespace Color_o_Magic_v2.Parameters;

public abstract class ComplexParameter
{
    [ComplexParameterCtor]
    protected ComplexParameter() { }

    public abstract Embed GetErrorEmbed();
}