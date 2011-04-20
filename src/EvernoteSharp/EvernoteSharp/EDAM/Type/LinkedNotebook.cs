/**
 * Autogenerated by Thrift
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Transport;
namespace Evernote.EDAM.Type
{

  [Serializable]
  public partial class LinkedNotebook : TBase
  {
    private long id;
    private string shareName;
    private string username;
    private string shardId;
    private string shareKey;
    private string uri;

    public long Id
    {
      get
      {
        return id;
      }
      set
      {
        __isset.id = true;
        this.id = value;
      }
    }

    public string ShareName
    {
      get
      {
        return shareName;
      }
      set
      {
        __isset.shareName = true;
        this.shareName = value;
      }
    }

    public string Username
    {
      get
      {
        return username;
      }
      set
      {
        __isset.username = true;
        this.username = value;
      }
    }

    public string ShardId
    {
      get
      {
        return shardId;
      }
      set
      {
        __isset.shardId = true;
        this.shardId = value;
      }
    }

    public string ShareKey
    {
      get
      {
        return shareKey;
      }
      set
      {
        __isset.shareKey = true;
        this.shareKey = value;
      }
    }

    public string Uri
    {
      get
      {
        return uri;
      }
      set
      {
        __isset.uri = true;
        this.uri = value;
      }
    }


    public Isset __isset;
    [Serializable]
    public struct Isset {
      public bool id;
      public bool shareName;
      public bool username;
      public bool shardId;
      public bool shareKey;
      public bool uri;
    }

    public LinkedNotebook() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.I64) {
              this.id = iprot.ReadI64();
              this.__isset.id = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              this.shareName = iprot.ReadString();
              this.__isset.shareName = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.String) {
              this.username = iprot.ReadString();
              this.__isset.username = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.String) {
              this.shardId = iprot.ReadString();
              this.__isset.shardId = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.String) {
              this.shareKey = iprot.ReadString();
              this.__isset.shareKey = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.String) {
              this.uri = iprot.ReadString();
              this.__isset.uri = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("LinkedNotebook");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.id) {
        field.Name = "id";
        field.Type = TType.I64;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(this.id);
        oprot.WriteFieldEnd();
      }
      if (this.shareName != null && __isset.shareName) {
        field.Name = "shareName";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.shareName);
        oprot.WriteFieldEnd();
      }
      if (this.username != null && __isset.username) {
        field.Name = "username";
        field.Type = TType.String;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.username);
        oprot.WriteFieldEnd();
      }
      if (this.shardId != null && __isset.shardId) {
        field.Name = "shardId";
        field.Type = TType.String;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.shardId);
        oprot.WriteFieldEnd();
      }
      if (this.shareKey != null && __isset.shareKey) {
        field.Name = "shareKey";
        field.Type = TType.String;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.shareKey);
        oprot.WriteFieldEnd();
      }
      if (this.uri != null && __isset.uri) {
        field.Name = "uri";
        field.Type = TType.String;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.uri);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("LinkedNotebook(");
      sb.Append("id: ");
      sb.Append(this.id);
      sb.Append(",shareName: ");
      sb.Append(this.shareName);
      sb.Append(",username: ");
      sb.Append(this.username);
      sb.Append(",shardId: ");
      sb.Append(this.shardId);
      sb.Append(",shareKey: ");
      sb.Append(this.shareKey);
      sb.Append(",uri: ");
      sb.Append(this.uri);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
