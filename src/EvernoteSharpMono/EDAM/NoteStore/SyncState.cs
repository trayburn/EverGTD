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
namespace Evernote.EDAM.NoteStore
{

  [Serializable]
  public partial class SyncState : TBase
  {
    private long currentTime;
    private long fullSyncBefore;
    private int updateCount;
    private long uploaded;

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

    public long FullSyncBefore
    {
      get
      {
        return fullSyncBefore;
      }
      set
      {
        __isset.fullSyncBefore = true;
        this.fullSyncBefore = value;
      }
    }

    public int UpdateCount
    {
      get
      {
        return updateCount;
      }
      set
      {
        __isset.updateCount = true;
        this.updateCount = value;
      }
    }

    public long Uploaded
    {
      get
      {
        return uploaded;
      }
      set
      {
        __isset.uploaded = true;
        this.uploaded = value;
      }
    }


    public Isset __isset;
    [Serializable]
    public struct Isset {
      public bool currentTime;
      public bool fullSyncBefore;
      public bool updateCount;
      public bool uploaded;
    }

    public SyncState() {
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
            if (field.Type == TType.I64) {
              this.fullSyncBefore = iprot.ReadI64();
              this.__isset.fullSyncBefore = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.I32) {
              this.updateCount = iprot.ReadI32();
              this.__isset.updateCount = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.I64) {
              this.uploaded = iprot.ReadI64();
              this.__isset.uploaded = true;
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
      TStruct struc = new TStruct("SyncState");
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
      if (__isset.fullSyncBefore) {
        field.Name = "fullSyncBefore";
        field.Type = TType.I64;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(this.fullSyncBefore);
        oprot.WriteFieldEnd();
      }
      if (__isset.updateCount) {
        field.Name = "updateCount";
        field.Type = TType.I32;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(this.updateCount);
        oprot.WriteFieldEnd();
      }
      if (__isset.uploaded) {
        field.Name = "uploaded";
        field.Type = TType.I64;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(this.uploaded);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("SyncState(");
      sb.Append("currentTime: ");
      sb.Append(this.currentTime);
      sb.Append(",fullSyncBefore: ");
      sb.Append(this.fullSyncBefore);
      sb.Append(",updateCount: ");
      sb.Append(this.updateCount);
      sb.Append(",uploaded: ");
      sb.Append(this.uploaded);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
