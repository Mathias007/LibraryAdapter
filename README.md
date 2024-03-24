`LibraryAdapter.cs` - pseudocode:
```
interface IOldLoggingLibrary:
    method LogMessage(message: string)

interface INewLoggingLibrary:
    method Log(message: string)

class NewToOldLoggingAdapter implements IOldLoggingLibrary:
    field newLoggingLibrary: INewLoggingLibrary

    constructor NewToOldLoggingAdapter(newLoggingLibrary: INewLoggingLibrary):
        this.newLoggingLibrary = newLoggingLibrary

    method LogMessage(message: string):
        newLoggingLibrary.Log(message)

class MessageLogger:
    field loggingLibrary: IOldLoggingLibrary

    constructor MessageLogger(loggingLibrary: IOldLoggingLibrary):
        this.loggingLibrary = loggingLibrary

    method LogMessage(message: string):
        loggingLibrary.LogMessage(message)

function Main():
    newLoggingLibrary = NewLoggingLibrary()

    adapter = NewToOldLoggingAdapter(newLoggingLibrary)

    logger = MessageLogger(adapter)

    logger.LogMessage("Test message")
```
