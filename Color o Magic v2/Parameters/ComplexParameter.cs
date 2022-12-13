using Discord.Interactions;

namespace Color_o_Magic_v2.Parameters;

public abstract class ComplexParameter
{
    [ComplexParameterCtor]
    protected ComplexParameter() { }

    /// <summary>
    /// Get the error as an embed.
    /// </summary>
    public abstract Discord.Embed GetErrorEmbed();
}