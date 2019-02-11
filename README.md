# DotNetStandard-Telegram
Class library written in dotnet standard for sending messages to telegram chats using a bot

## Installation
Package Manager: `Install-Package DotNetStandard-Telegram`
<br>
.Net CLI: `dotnet add package DotNetStandard-Telegram`

## Usage
Initliase a new instance of the service as follows, provided a bot api key and a group id - [Telegram bot docs](https://core.telegram.org/bots)
`DotNetStandard_Telegram.Telegram telegram = new Telegram("BotAPIKey", "ChatId");`

The method to send a message is called 'sendMessage'. There are three possible ways of using this...
1. Sending just a message:
`telegram.sendMessage("message to send");`

2. Sending a message with a source string, useful for when messages are being sent from multiple applications:
`telegram.sendMessage("message to send", "message source");`

3. Sending a message with a source string and a severity, useful for alerting of errors:
`telegram.sendMessage("message to send", "message source", DotNetStandard_Telegram.Telegram.Severity.Information);`

There are three possible states for severity:
  * DotNetStandard_Telegram.Telegram.Severity.Information
  * DotNetStandard_Telegram.Telegram.Severity.Trace
  * DotNetStandard_Telegram.Telegram.Severity.Error
