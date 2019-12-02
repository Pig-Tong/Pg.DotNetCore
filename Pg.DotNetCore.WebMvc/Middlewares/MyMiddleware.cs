using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pg.DotNetCore.WebMvc.Middlewares
{
    public class MyMiddleware
    {
        //第一步： 
        private RequestDelegate _next;
        //加一个构造方法.构造方法第一个参数必须是 RequestDelegate类型，表示为中间件类型，
        //即是表示为下一个中间件。定义中间件时必须包含对下一个中间件的引用
        public MyMiddleware(RequestDelegate next)
        {
            //通过私有字段去接收下一个中间件的 引用，因为我们在其他地方需要用这个下一个中间件next。这步是关 键，必须的有，这个实现把中间件串联起来 
            this._next = next;
        }

        //第二步增加Task InvokeAsync(HttpContext context)方 法，方法名称固定为InvokeAsync,返回值为Task 
        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("test");
             if (!context.Response.HasStarted)
            {
                await this._next.Invoke(context);
            }            
        }
    }
}

