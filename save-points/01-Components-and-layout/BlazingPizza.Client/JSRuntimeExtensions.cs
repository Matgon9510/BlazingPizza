using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazingPizza.Client;

public static class JSRuntimeExtensions
{
    public static ValueTask<bool> Confirm(this IJSRuntime jsRuntime, string message)
    {
        // Llamamos a la función confirm() de JavaScript
        return jsRuntime.InvokeAsync<bool>("confirm", message);
    }
}
