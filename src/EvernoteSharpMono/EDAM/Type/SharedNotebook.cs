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
  public partial class SharedNotebook : TBase
  {
    private long id;
    private int userId;
    private string notebookGuid;
    private string email;
    private bool notebookModifiable;
    private bool requireLogin;
    private long serviceCreated;
    private string shareKey;
    private string username;

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

    public int UserId
    {
      get
      {
        return userId;
      }
      set
      {
        __isset.userId = true;
        this.userId = value;
      }
    }

    public string NotebookGuid
    {
      get
      {
        return notebookGuid;
      }
      set
      {
        __isset.notebookGuid = true;
        this.notebookGuid = value;
      }
    }

    public string Email
    {
      get
      {
        return email;
      }
      set
      {
        __isset.email = true;
        this.email = value;
      }
    }

    public bool NotebookModifiable
    {
      get
      {
        return notebookModifiable;
      }
      set
      {
        __isset.notebookModifiable = true;
        this.notebookModifiable = value;
      }
    }

    public bool RequireLogin
    {
      get
      {
        return requireLogin;
      }
      set
      {
        __isset.requireLogin = true;
        this.requireLogin = value;
      }
    }

    public long ServiceCreated
    {
      get
      {
        return serviceCreated;
      }
      set
      {
        __isset.serviceCreated = true;
        this.serviceCreated = value;
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


    public Isset __isset;
    [Serializable]
    public struct Isset {
      public bool id;
      public bool userId;
      public bool notebookGuid;
      public bool email;
      public bool notebookModifiable;
      public bool requireLogin;
      public bool serviceCreated;
      public bool shareKey;
      public bool username;
    }

    public SharedNotebook() {
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
            if (field.Type == TType.I32) {
              this.userId = iprot.ReadI32();
              this.__isset.userId = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.String) {
              this.notebookGuid = iprot.ReadString();
              this.__isset.notebookGuid = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.String) {
              this.email = iprot.ReadString();
              this.__isset.email = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.Bool) {
              this.notebookModifiable = iprot.ReadBool();
              this.__isset.notebookModifiable = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.Bool) {
              this.requireLogin = iprot.ReadBool();
              this.__isset.requireLogin = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.I64) {
              this.serviceCreated = iprot.ReadI64();
              this.__isset.serviceCreated = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 8:
            if (field.Type == TType.String) {
              this.shareKey = iprot.ReadString();
              this.__isset.shareKey = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.String) {
              this.username = iprot.ReadString();
              this.__isset.username = true;
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
      TStruct struc = new TStruct("SharedNotebook");
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
      if (__isset.userId) {
        field.Name = "userId";
        field.Type = TType.I32;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(this.userId);
        oprot.WriteFieldEnd();
      }
      if (this.notebookGuid != null && __isset.notebookGuid) {
        field.Name = "notebookGuid";
        field.Type = TType.String;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.notebookGuid);
        oprot.WriteFieldEnd();
      }
      if (this.email != null && __isset.email) {
        field.Name = "email";
        field.Type = TType.String;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.email);
        oprot.WriteFieldEnd();
      }
      if (__isset.notebookModifiable) {
        field.Name = "notebookModifiable";
        field.Type = TType.Bool;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(this.notebookModifiable);
        oprot.WriteFieldEnd();
      }
      if (__isset.requireLogin) {
        field.Name = "requireLogin";
        field.Type = TType.Bool;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(this.requireLogin);
        oprot.WriteFieldEnd();
      }
      if (__isset.serviceCreated) {
        field.Name = "serviceCreated";
        field.Type = TType.I64;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(this.serviceCreated);
        oprot.WriteFieldEnd();
      }
      if (this.shareKey != null && __isset.shareKey) {
        field.Name = "shareKey";
        field.Type = TType.String;
        field.ID = 8;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.shareKey);
        oprot.WriteFieldEnd();
      }
      if (this.username != null && __isset.username) {
        field.Name = "username";
        field.Type = TType.String;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.username);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("SharedNotebook(");
      sb.Append("id: ");
      sb.Append(this.id);
      sb.Append(",userId: ");
      sb.Append(this.userId);
      sb.Append(",notebookGuid: ");
      sb.Append(this.notebookGuid);
      sb.Append(",email: ");
      sb.Append(this.email);
      sb.Append(",notebookModifiable: ");
      sb.Append(this.notebookModifiable);
      sb.Append(",requireLogin: ");
      sb.Append(this.requireLogin);
      sb.Append(",serviceCreated: ");
      sb.Append(this.serviceCreated);
      sb.Append(",shareKey: ");
      sb.Append(this.shareKey);
      sb.Append(",username: ");
      sb.Append(this.username);
      sb.Append(")");
      return sb.ToString();
    }

  }

}