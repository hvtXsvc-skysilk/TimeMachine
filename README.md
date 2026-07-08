# The Time Machine!
您可以用这个程序进行**时间穿越**！
- 有一些预设值，五秒，十秒，十年等，还有自定义功能！
- 使用了异步方法，如果想要中途停止，直接换一个时间再次选择！
``` csharp
private async void button1_Click(object sender, EventArgs e)
{
    async Task DelayInChunks(int Sec)
    {
        while (Sec > 0)
        {
            int wait = Math.Min(1, Sec);
            await Task.Delay(TimeSpan.FromSeconds(wait));
            Sec -= wait;
        }
    }

    switch (index)
    {
        case 0: 
            // ......
    }
    
}
```
- 进行愉快的一段旅程吧！
