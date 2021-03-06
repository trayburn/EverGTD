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
namespace Evernote.EDAM.Error
{

  [Serializable]
  public partial class EDAMSystemException : Exception, TBase
  {
    private EDAMErrorCode errorCode;
    private string message;

    public EDAMErrorCode ErrorCode
    {
      get
      {
        return errorCode;
      }
      set
      {
        __isset.errorCode = true;
        this.errorCode = value;
      }
    }

    public string Message
    {
      get
      {
        return message;
      }
      set
      {
        __isset.message = true;
        this.message = value;
      }
    }


    public Isset __isset;
    [Serializable]
    public struct Isset {
      public bool errorCode;
      public bool message;
    }

    public EDAMSystemException() {
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
            if (field.Type == TType.I32) {
              this.errorCode = (EDAMErrorCode)iprot.ReadI32();
              this.__isset.errorCode = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              this.message = iprot.ReadString();
              this.__isset.message = true;
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
      TStruct struc = new TStruct("EDAMSystemException");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.errorCode) {
        field.Name = "errorCode";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)this.errorCode);
        oprot.WriteFieldEnd();
      }
      if (this.message != null && __isset.message) {
        field.Name = "message";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.message);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("EDAMSystemException(");
      sb.Append("errorCode: ");
      sb.Append(this.errorCode);
      sb.Append(",message: ");
      sb.Append(this.message);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
