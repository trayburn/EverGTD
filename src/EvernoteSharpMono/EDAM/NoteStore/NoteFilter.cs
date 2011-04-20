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
  public partial class NoteFilter : TBase
  {
    private Evernote.EDAM.Type.NoteSortOrder order;
    private bool ascending;
    private string words;
    private string notebookGuid;
    private List<string> tagGuids;
    private string timeZone;
    private bool inactive;

    public Evernote.EDAM.Type.NoteSortOrder Order
    {
      get
      {
        return order;
      }
      set
      {
        __isset.order = true;
        this.order = value;
      }
    }

    public bool Ascending
    {
      get
      {
        return ascending;
      }
      set
      {
        __isset.ascending = true;
        this.ascending = value;
      }
    }

    public string Words
    {
      get
      {
        return words;
      }
      set
      {
        __isset.words = true;
        this.words = value;
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

    public List<string> TagGuids
    {
      get
      {
        return tagGuids;
      }
      set
      {
        __isset.tagGuids = true;
        this.tagGuids = value;
      }
    }

    public string TimeZone
    {
      get
      {
        return timeZone;
      }
      set
      {
        __isset.timeZone = true;
        this.timeZone = value;
      }
    }

    public bool Inactive
    {
      get
      {
        return inactive;
      }
      set
      {
        __isset.inactive = true;
        this.inactive = value;
      }
    }


    public Isset __isset;
    [Serializable]
    public struct Isset {
      public bool order;
      public bool ascending;
      public bool words;
      public bool notebookGuid;
      public bool tagGuids;
      public bool timeZone;
      public bool inactive;
    }

    public NoteFilter() {
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
              this.order = (Evernote.EDAM.Type.NoteSortOrder)iprot.ReadI32();
              this.__isset.order = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Bool) {
              this.ascending = iprot.ReadBool();
              this.__isset.ascending = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.String) {
              this.words = iprot.ReadString();
              this.__isset.words = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.String) {
              this.notebookGuid = iprot.ReadString();
              this.__isset.notebookGuid = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.List) {
              {
                this.tagGuids = new List<string>();
                TList _list36 = iprot.ReadListBegin();
                for( int _i37 = 0; _i37 < _list36.Count; ++_i37)
                {
                  string _elem38 = null;
                  _elem38 = iprot.ReadString();
                  this.tagGuids.Add(_elem38);
                }
                iprot.ReadListEnd();
              }
              this.__isset.tagGuids = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.String) {
              this.timeZone = iprot.ReadString();
              this.__isset.timeZone = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.Bool) {
              this.inactive = iprot.ReadBool();
              this.__isset.inactive = true;
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
      TStruct struc = new TStruct("NoteFilter");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.order) {
        field.Name = "order";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)this.order);
        oprot.WriteFieldEnd();
      }
      if (__isset.ascending) {
        field.Name = "ascending";
        field.Type = TType.Bool;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(this.ascending);
        oprot.WriteFieldEnd();
      }
      if (this.words != null && __isset.words) {
        field.Name = "words";
        field.Type = TType.String;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.words);
        oprot.WriteFieldEnd();
      }
      if (this.notebookGuid != null && __isset.notebookGuid) {
        field.Name = "notebookGuid";
        field.Type = TType.String;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.notebookGuid);
        oprot.WriteFieldEnd();
      }
      if (this.tagGuids != null && __isset.tagGuids) {
        field.Name = "tagGuids";
        field.Type = TType.List;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.String, this.tagGuids.Count));
          foreach (string _iter39 in this.tagGuids)
          {
            oprot.WriteString(_iter39);
            oprot.WriteListEnd();
          }
        }
        oprot.WriteFieldEnd();
      }
      if (this.timeZone != null && __isset.timeZone) {
        field.Name = "timeZone";
        field.Type = TType.String;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.timeZone);
        oprot.WriteFieldEnd();
      }
      if (__isset.inactive) {
        field.Name = "inactive";
        field.Type = TType.Bool;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(this.inactive);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("NoteFilter(");
      sb.Append("order: ");
      sb.Append(this.order);
      sb.Append(",ascending: ");
      sb.Append(this.ascending);
      sb.Append(",words: ");
      sb.Append(this.words);
      sb.Append(",notebookGuid: ");
      sb.Append(this.notebookGuid);
      sb.Append(",tagGuids: ");
      sb.Append(this.tagGuids);
      sb.Append(",timeZone: ");
      sb.Append(this.timeZone);
      sb.Append(",inactive: ");
      sb.Append(this.inactive);
      sb.Append(")");
      return sb.ToString();
    }

  }

}