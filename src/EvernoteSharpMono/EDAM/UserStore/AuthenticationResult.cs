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
namespace Evernote.EDAM.UserStore
{

  [Serializable]
  public partial class AuthenticationResult : TBase
  {
    private long currentTime;
    private string authenticationToken;
    private long expiration;
    private Evernote.EDAM.Type.User user;
    private PublicUserInfo publicUserInfo;

    public long CurrentTime
    {
      get
      {
        return currentTime;
      }
      set
      {
        __isset.currentTime = true;
        this.currentTime = value;
      }
    }

    public string AuthenticationToken
    {
      get
      {
        return authenticationToken;
      }
      set
      {
        __isset.authenticationToken = true;
        this.authenticationToken = value;
      }
    }

    public long Expiration
    {
      get
      {
        return expiration;
      }
      set
      {
        __isset.expiration = true;
        this.expiration = value;
      }
    }

    public Evernote.EDAM.Type.User User
    {
      get
      {
        return user;
      }
      set
      {
        __isset.user = true;
        this.user = value;
      }
    }

    public PublicUserInfo PublicUserInfo
    {
      get
      {
        return publicUserInfo;
      }
      set
      {
        __isset.publicUserInfo = true;
        this.publicUserInfo = value;
      }
    }


    public Isset __isset;
    [Serializable]
    public struct Isset {
      public bool currentTime;
      public bool authenticationToken;
      public bool expiration;
      public bool user;
      public bool publicUserInfo;
    }

    public AuthenticationResult() {
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
              this.currentTime = iprot.ReadI64();
              this.__isset.currentTime = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              this.authenticationToken = iprot.ReadString();
              this.__isset.authenticationToken = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.I64) {
              this.expiration = iprot.ReadI64();
              this.__isset.expiration = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Struct) {
              this.user = new Evernote.EDAM.Type.User();
              this.user.Read(iprot);
              this.__isset.user = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.Struct) {
              this.publicUserInfo = new PublicUserInfo();
              this.publicUserInfo.Read(iprot);
              this.__isset.publicUserInfo = true;
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
      TStruct struc = new TStruct("AuthenticationResult");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.currentTime) {
        field.Name = "currentTime";
        field.Type = TType.I64;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(this.currentTime);
        oprot.WriteFieldEnd();
      }
      if (this.authenticationToken != null && __isset.authenticationToken) {
        field.Name = "authenticationToken";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.authenticationToken);
        oprot.WriteFieldEnd();
      }
      if (__isset.expiration) {
        field.Name = "expiration";
        field.Type = TType.I64;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(this.expiration);
        oprot.WriteFieldEnd();
      }
      if (this.user != null && __isset.user) {
        field.Name = "user";
        field.Type = TType.Struct;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        this.user.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (this.publicUserInfo != null && __isset.publicUserInfo) {
        field.Name = "publicUserInfo";
        field.Type = TType.Struct;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        this.publicUserInfo.Write(oprot);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("AuthenticationResult(");
      sb.Append("currentTime: ");
      sb.Append(this.currentTime);
      sb.Append(",authenticationToken: ");
      sb.Append(this.authenticationToken);
      sb.Append(",expiration: ");
      sb.Append(this.expiration);
      sb.Append(",user: ");
      sb.Append(this.user== null ? "<null>" : this.user.ToString());
      sb.Append(",publicUserInfo: ");
      sb.Append(this.publicUserInfo== null ? "<null>" : this.publicUserInfo.ToString());
      sb.Append(")");
      return sb.ToString();
    }

  }

}
