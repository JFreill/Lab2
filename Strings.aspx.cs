using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public class ExtensionMethods
{
    public string ToUpperLower(string inputString)
    {

        int i = 0;
        char[] input = inputString.ToLower().ToCharArray();
        while (i < input.Length)
        {
            input[i] = char.ToUpper(input[i]);
            i += 2;
        }
        return new string(input);
    }
}
/// <summary>
/// Summary description for _Strings
/// </summary>
public partial class _Strings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void inputButton_OnClick(Object sender, EventArgs e)
    {
        this.outputLiteral.Text = this.inputTextBox.Text.ToUpperLower();
    }
}

