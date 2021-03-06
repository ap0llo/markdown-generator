﻿<!--  
  <auto-generated>   
    The contents of this file were generated by a tool.  
    Changes to this file may be list if the file is regenerated  
  </auto-generated>   
-->

# MdDocument.Save Method

**Declaring Type:** [MdDocument](../index.md)  
**Namespace:** [Grynwald.MarkdownGenerator](../../index.md)  
**Assembly:** Grynwald.MarkdownGenerator

## Overloads

| Signature                                                                  | Description                                                                         |
| -------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| [Save(Stream)](#savestream)                                                | Saves the document to a stream.                                                     |
| [Save(Stream, MdSerializationOptions)](#savestream-mdserializationoptions) | Saves the document to a stream using the specified serialization options.           |
| [Save(string)](#savestring)                                                | Saves the document to the specified file.                                           |
| [Save(string, MdSerializationOptions)](#savestring-mdserializationoptions) | Saves the document to the specified file using the specified serialization options. |

## Save(Stream)

Saves the document to a stream.

```csharp
public void Save(Stream stream);
```

### Parameters

`stream`  Stream

The stream to write the document to.

## Save(Stream, MdSerializationOptions)

Saves the document to a stream using the specified serialization options.

```csharp
public void Save(Stream stream, MdSerializationOptions serializationOptions);
```

### Parameters

`stream`  Stream

The stream to write the document to.

`serializationOptions`  [MdSerializationOptions](../../MdSerializationOptions/index.md)

The options to use for converting the document to Markdown.

## Save(string)

Saves the document to the specified file.

```csharp
public void Save(string path);
```

### Parameters

`path`  string

The path of the file to save the document to.

## Save(string, MdSerializationOptions)

Saves the document to the specified file using the specified serialization options.

```csharp
public void Save(string path, MdSerializationOptions serializationOptions);
```

### Parameters

`path`  string

The path of the file to save the document to.

`serializationOptions`  [MdSerializationOptions](../../MdSerializationOptions/index.md)

The options to use for serialization.

___

*Documentation generated by [MdDocs](https://github.com/ap0llo/mddocs)*
