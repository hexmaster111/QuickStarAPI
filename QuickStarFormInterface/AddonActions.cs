namespace QuickStarFormInterface;

public class LibInfo
{
    public static readonly int QuickStarFormInterfaceVersion = 1;
}

public enum AddonAddress
{
    None = 0,
    DebugAddon0 = 0x01,
    DebugAddon1 = 0x02,
    DebugAddon2 = 0x03,
    DebugAddon3 = 0x04,

    VapeController0 = 0x05,
    VapeController1 = 0x06,
    VapeController2 = 0x07,
    VapeController3 = 0x08,

    //MCP Input card resurved
    Mcp23017InputCard0 = 0x20, //000
    Mcp23017InputCard1 = 0x21, //001
    Mcp23017InputCard2 = 0x22, //010
    Mcp23017InputCard3 = 0x23, //011
    Mcp23017InputCard4 = 0x24, //100
    Mcp23017InputCard5 = 0x25, //101
    Mcp23017InputCard6 = 0x26, //110
    Mcp23017InputCard7 = 0x27, //111
}

/// <summary>
/// Class that handles addon communication.
/// </summary>
public abstract class AddonCommunication
{
    /// <summary>
    /// Returns the current stored value of a addons registers.
    /// </summary>
    /// <param name="i2CAddress">I2C Address of the addon</param>
    /// <param name="registerNumber">Register Number To get the value from</param>
    /// <param name="value">Return value of the register</param>
    /// <returns>If the opperation was sucessfull</returns>
    public abstract bool GetRegisterValue(byte i2CAddress, byte registerNumber, out byte value);

    /// <summary>
    /// Sets the value of a register in an addon.
    /// </summary>
    /// <param name="address">I2C Address of the addon</param>
    /// <param name="register">Register number to write the data to</param>
    /// <param name="value">Value to write to the register</param>
    /// <returns>Message Queued ok</returns>
    public abstract bool SetRegisterValue(byte address, byte register, byte value);

    /// <summary>
    /// Retuns if the addon is connected 
    /// </summary>
    /// <param name="address">Address to check</param>
    /// <returns>Is Connected</returns>
    public abstract bool IsConnected(byte address);
}

public interface IPluginInterface
{
    public string PluginName { get; }
    public string PluginVersion { get; }
    public string PluginAuthor { get; }
    public string PluginDescription { get; }

    //List of addons that the form can work with
    public AddonAddress[] UsableAddonsList { get; set; }

    //Actions rased by controller
    public Action ShowWindow { set; get; }
    public Action HideWindow { set; get; }
    public Action CloseWindow { set; get; }

    public Action ShowSettingsWindow { set; get; }
    public Action ShowAboutWindow { set; get; }

    //Rased when the app is exiting
    public Action Closing { set; get; }
    
    
    //Called when the app is starting
    public void PluginInit(AddonCommunication communication);

    //Thread Started on plugin load
    public int PluginMainThread();
}