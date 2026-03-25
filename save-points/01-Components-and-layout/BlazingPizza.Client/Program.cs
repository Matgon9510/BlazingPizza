using BlazingPizza.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazingPizza.Client;







var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HttpClient genérico (para specials, toppings, etc.)
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Estado de la orden
builder.Services.AddScoped<OrderState>();

// 👇 OrdersClient tipado con handler que añade el token
builder.Services.AddHttpClient<OrdersClient>(client =>
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// 👇 Auth con estado personalizado
builder.Services.AddApiAuthorization<PizzaAuthenticationState>(options =>
{
    // Después de cerrar sesión, vuelve a la página principal
    options.AuthenticationPaths.LogOutSucceededPath = "";
});

await builder.Build().RunAsync();
