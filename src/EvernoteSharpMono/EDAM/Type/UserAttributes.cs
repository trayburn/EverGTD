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
  public partial class UserAttributes : TBase
  {
    private string defaultLocationName;
    private double defaultLatitude;
    private double defaultLongitude;
    private bool preactivation;
    private List<string> viewedPromotions;
    private string incomingEmailAddress;
    private List<string> recentMailedAddresses;
    private string comments;
    private long dateAgreedToTermsOfService;
    private int maxReferrals;
    private int referralCount;
    private string refererCode;
    private long sentEmailDate;
    private int sentEmailCount;
    private int dailyEmailLimit;
    private long emailOptOutDate;
    private long partnerEmailOptInDate;
    private string preferredLanguage;
    private string preferredCountry;
    private bool clipFullPage;
    private string twitterUserName;
    private string twitterId;

    public string DefaultLocationName
    {
      get
      {
        return defaultLocationName;
      }
      set
      {
        __isset.defaultLocationName = true;
        this.defaultLocationName = value;
      }
    }

    public double DefaultLatitude
    {
      get
      {
        return defaultLatitude;
      }
      set
      {
        __isset.defaultLatitude = true;
        this.defaultLatitude = value;
      }
    }

    public double DefaultLongitude
    {
      get
      {
        return defaultLongitude;
      }
      set
      {
        __isset.defaultLongitude = true;
        this.defaultLongitude = value;
      }
    }

    public bool Preactivation
    {
      get
      {
        return preactivation;
      }
      set
      {
        __isset.preactivation = true;
        this.preactivation = value;
      }
    }

    public List<string> ViewedPromotions
    {
      get
      {
        return viewedPromotions;
      }
      set
      {
        __isset.viewedPromotions = true;
        this.viewedPromotions = value;
      }
    }

    public string IncomingEmailAddress
    {
      get
      {
        return incomingEmailAddress;
      }
      set
      {
        __isset.incomingEmailAddress = true;
        this.incomingEmailAddress = value;
      }
    }

    public List<string> RecentMailedAddresses
    {
      get
      {
        return recentMailedAddresses;
      }
      set
      {
        __isset.recentMailedAddresses = true;
        this.recentMailedAddresses = value;
      }
    }

    public string Comments
    {
      get
      {
        return comments;
      }
      set
      {
        __isset.comments = true;
        this.comments = value;
      }
    }

    public long DateAgreedToTermsOfService
    {
      get
      {
        return dateAgreedToTermsOfService;
      }
      set
      {
        __isset.dateAgreedToTermsOfService = true;
        this.dateAgreedToTermsOfService = value;
      }
    }

    public int MaxReferrals
    {
      get
      {
        return maxReferrals;
      }
      set
      {
        __isset.maxReferrals = true;
        this.maxReferrals = value;
      }
    }

    public int ReferralCount
    {
      get
      {
        return referralCount;
      }
      set
      {
        __isset.referralCount = true;
        this.referralCount = value;
      }
    }

    public string RefererCode
    {
      get
      {
        return refererCode;
      }
      set
      {
        __isset.refererCode = true;
        this.refererCode = value;
      }
    }

    public long SentEmailDate
    {
      get
      {
        return sentEmailDate;
      }
      set
      {
        __isset.sentEmailDate = true;
        this.sentEmailDate = value;
      }
    }

    public int SentEmailCount
    {
      get
      {
        return sentEmailCount;
      }
      set
      {
        __isset.sentEmailCount = true;
        this.sentEmailCount = value;
      }
    }

    public int DailyEmailLimit
    {
      get
      {
        return dailyEmailLimit;
      }
      set
      {
        __isset.dailyEmailLimit = true;
        this.dailyEmailLimit = value;
      }
    }

    public long EmailOptOutDate
    {
      get
      {
        return emailOptOutDate;
      }
      set
      {
        __isset.emailOptOutDate = true;
        this.emailOptOutDate = value;
      }
    }

    public long PartnerEmailOptInDate
    {
      get
      {
        return partnerEmailOptInDate;
      }
      set
      {
        __isset.partnerEmailOptInDate = true;
        this.partnerEmailOptInDate = value;
      }
    }

    public string PreferredLanguage
    {
      get
      {
        return preferredLanguage;
      }
      set
      {
        __isset.preferredLanguage = true;
        this.preferredLanguage = value;
      }
    }

    public string PreferredCountry
    {
      get
      {
        return preferredCountry;
      }
      set
      {
        __isset.preferredCountry = true;
        this.preferredCountry = value;
      }
    }

    public bool ClipFullPage
    {
      get
      {
        return clipFullPage;
      }
      set
      {
        __isset.clipFullPage = true;
        this.clipFullPage = value;
      }
    }

    public string TwitterUserName
    {
      get
      {
        return twitterUserName;
      }
      set
      {
        __isset.twitterUserName = true;
        this.twitterUserName = value;
      }
    }

    public string TwitterId
    {
      get
      {
        return twitterId;
      }
      set
      {
        __isset.twitterId = true;
        this.twitterId = value;
      }
    }


    public Isset __isset;
    [Serializable]
    public struct Isset {
      public bool defaultLocationName;
      public bool defaultLatitude;
      public bool defaultLongitude;
      public bool preactivation;
      public bool viewedPromotions;
      public bool incomingEmailAddress;
      public bool recentMailedAddresses;
      public bool comments;
      public bool dateAgreedToTermsOfService;
      public bool maxReferrals;
      public bool referralCount;
      public bool refererCode;
      public bool sentEmailDate;
      public bool sentEmailCount;
      public bool dailyEmailLimit;
      public bool emailOptOutDate;
      public bool partnerEmailOptInDate;
      public bool preferredLanguage;
      public bool preferredCountry;
      public bool clipFullPage;
      public bool twitterUserName;
      public bool twitterId;
    }

    public UserAttributes() {
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
            if (field.Type == TType.String) {
              this.defaultLocationName = iprot.ReadString();
              this.__isset.defaultLocationName = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Double) {
              this.defaultLatitude = iprot.ReadDouble();
              this.__isset.defaultLatitude = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Double) {
              this.defaultLongitude = iprot.ReadDouble();
              this.__isset.defaultLongitude = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Bool) {
              this.preactivation = iprot.ReadBool();
              this.__isset.preactivation = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.List) {
              {
                this.viewedPromotions = new List<string>();
                TList _list0 = iprot.ReadListBegin();
                for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                {
                  string _elem2 = null;
                  _elem2 = iprot.ReadString();
                  this.viewedPromotions.Add(_elem2);
                }
                iprot.ReadListEnd();
              }
              this.__isset.viewedPromotions = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.String) {
              this.incomingEmailAddress = iprot.ReadString();
              this.__isset.incomingEmailAddress = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.List) {
              {
                this.recentMailedAddresses = new List<string>();
                TList _list3 = iprot.ReadListBegin();
                for( int _i4 = 0; _i4 < _list3.Count; ++_i4)
                {
                  string _elem5 = null;
                  _elem5 = iprot.ReadString();
                  this.recentMailedAddresses.Add(_elem5);
                }
                iprot.ReadListEnd();
              }
              this.__isset.recentMailedAddresses = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.String) {
              this.comments = iprot.ReadString();
              this.__isset.comments = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 11:
            if (field.Type == TType.I64) {
              this.dateAgreedToTermsOfService = iprot.ReadI64();
              this.__isset.dateAgreedToTermsOfService = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 12:
            if (field.Type == TType.I32) {
              this.maxReferrals = iprot.ReadI32();
              this.__isset.maxReferrals = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 13:
            if (field.Type == TType.I32) {
              this.referralCount = iprot.ReadI32();
              this.__isset.referralCount = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 14:
            if (field.Type == TType.String) {
              this.refererCode = iprot.ReadString();
              this.__isset.refererCode = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 15:
            if (field.Type == TType.I64) {
              this.sentEmailDate = iprot.ReadI64();
              this.__isset.sentEmailDate = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 16:
            if (field.Type == TType.I32) {
              this.sentEmailCount = iprot.ReadI32();
              this.__isset.sentEmailCount = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 17:
            if (field.Type == TType.I32) {
              this.dailyEmailLimit = iprot.ReadI32();
              this.__isset.dailyEmailLimit = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 18:
            if (field.Type == TType.I64) {
              this.emailOptOutDate = iprot.ReadI64();
              this.__isset.emailOptOutDate = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 19:
            if (field.Type == TType.I64) {
              this.partnerEmailOptInDate = iprot.ReadI64();
              this.__isset.partnerEmailOptInDate = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.String) {
              this.preferredLanguage = iprot.ReadString();
              this.__isset.preferredLanguage = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 21:
            if (field.Type == TType.String) {
              this.preferredCountry = iprot.ReadString();
              this.__isset.preferredCountry = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 22:
            if (field.Type == TType.Bool) {
              this.clipFullPage = iprot.ReadBool();
              this.__isset.clipFullPage = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 23:
            if (field.Type == TType.String) {
              this.twitterUserName = iprot.ReadString();
              this.__isset.twitterUserName = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 24:
            if (field.Type == TType.String) {
              this.twitterId = iprot.ReadString();
              this.__isset.twitterId = true;
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
      TStruct struc = new TStruct("UserAttributes");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (this.defaultLocationName != null && __isset.defaultLocationName) {
        field.Name = "defaultLocationName";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.defaultLocationName);
        oprot.WriteFieldEnd();
      }
      if (__isset.defaultLatitude) {
        field.Name = "defaultLatitude";
        field.Type = TType.Double;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(this.defaultLatitude);
        oprot.WriteFieldEnd();
      }
      if (__isset.defaultLongitude) {
        field.Name = "defaultLongitude";
        field.Type = TType.Double;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(this.defaultLongitude);
        oprot.WriteFieldEnd();
      }
      if (__isset.preactivation) {
        field.Name = "preactivation";
        field.Type = TType.Bool;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(this.preactivation);
        oprot.WriteFieldEnd();
      }
      if (this.viewedPromotions != null && __isset.viewedPromotions) {
        field.Name = "viewedPromotions";
        field.Type = TType.List;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.String, this.viewedPromotions.Count));
          foreach (string _iter6 in this.viewedPromotions)
          {
            oprot.WriteString(_iter6);
            oprot.WriteListEnd();
          }
        }
        oprot.WriteFieldEnd();
      }
      if (this.incomingEmailAddress != null && __isset.incomingEmailAddress) {
        field.Name = "incomingEmailAddress";
        field.Type = TType.String;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.incomingEmailAddress);
        oprot.WriteFieldEnd();
      }
      if (this.recentMailedAddresses != null && __isset.recentMailedAddresses) {
        field.Name = "recentMailedAddresses";
        field.Type = TType.List;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.String, this.recentMailedAddresses.Count));
          foreach (string _iter7 in this.recentMailedAddresses)
          {
            oprot.WriteString(_iter7);
            oprot.WriteListEnd();
          }
        }
        oprot.WriteFieldEnd();
      }
      if (this.comments != null && __isset.comments) {
        field.Name = "comments";
        field.Type = TType.String;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.comments);
        oprot.WriteFieldEnd();
      }
      if (__isset.dateAgreedToTermsOfService) {
        field.Name = "dateAgreedToTermsOfService";
        field.Type = TType.I64;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(this.dateAgreedToTermsOfService);
        oprot.WriteFieldEnd();
      }
      if (__isset.maxReferrals) {
        field.Name = "maxReferrals";
        field.Type = TType.I32;
        field.ID = 12;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(this.maxReferrals);
        oprot.WriteFieldEnd();
      }
      if (__isset.referralCount) {
        field.Name = "referralCount";
        field.Type = TType.I32;
        field.ID = 13;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(this.referralCount);
        oprot.WriteFieldEnd();
      }
      if (this.refererCode != null && __isset.refererCode) {
        field.Name = "refererCode";
        field.Type = TType.String;
        field.ID = 14;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.refererCode);
        oprot.WriteFieldEnd();
      }
      if (__isset.sentEmailDate) {
        field.Name = "sentEmailDate";
        field.Type = TType.I64;
        field.ID = 15;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(this.sentEmailDate);
        oprot.WriteFieldEnd();
      }
      if (__isset.sentEmailCount) {
        field.Name = "sentEmailCount";
        field.Type = TType.I32;
        field.ID = 16;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(this.sentEmailCount);
        oprot.WriteFieldEnd();
      }
      if (__isset.dailyEmailLimit) {
        field.Name = "dailyEmailLimit";
        field.Type = TType.I32;
        field.ID = 17;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(this.dailyEmailLimit);
        oprot.WriteFieldEnd();
      }
      if (__isset.emailOptOutDate) {
        field.Name = "emailOptOutDate";
        field.Type = TType.I64;
        field.ID = 18;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(this.emailOptOutDate);
        oprot.WriteFieldEnd();
      }
      if (__isset.partnerEmailOptInDate) {
        field.Name = "partnerEmailOptInDate";
        field.Type = TType.I64;
        field.ID = 19;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(this.partnerEmailOptInDate);
        oprot.WriteFieldEnd();
      }
      if (this.preferredLanguage != null && __isset.preferredLanguage) {
        field.Name = "preferredLanguage";
        field.Type = TType.String;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.preferredLanguage);
        oprot.WriteFieldEnd();
      }
      if (this.preferredCountry != null && __isset.preferredCountry) {
        field.Name = "preferredCountry";
        field.Type = TType.String;
        field.ID = 21;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.preferredCountry);
        oprot.WriteFieldEnd();
      }
      if (__isset.clipFullPage) {
        field.Name = "clipFullPage";
        field.Type = TType.Bool;
        field.ID = 22;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(this.clipFullPage);
        oprot.WriteFieldEnd();
      }
      if (this.twitterUserName != null && __isset.twitterUserName) {
        field.Name = "twitterUserName";
        field.Type = TType.String;
        field.ID = 23;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.twitterUserName);
        oprot.WriteFieldEnd();
      }
      if (this.twitterId != null && __isset.twitterId) {
        field.Name = "twitterId";
        field.Type = TType.String;
        field.ID = 24;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(this.twitterId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("UserAttributes(");
      sb.Append("defaultLocationName: ");
      sb.Append(this.defaultLocationName);
      sb.Append(",defaultLatitude: ");
      sb.Append(this.defaultLatitude);
      sb.Append(",defaultLongitude: ");
      sb.Append(this.defaultLongitude);
      sb.Append(",preactivation: ");
      sb.Append(this.preactivation);
      sb.Append(",viewedPromotions: ");
      sb.Append(this.viewedPromotions);
      sb.Append(",incomingEmailAddress: ");
      sb.Append(this.incomingEmailAddress);
      sb.Append(",recentMailedAddresses: ");
      sb.Append(this.recentMailedAddresses);
      sb.Append(",comments: ");
      sb.Append(this.comments);
      sb.Append(",dateAgreedToTermsOfService: ");
      sb.Append(this.dateAgreedToTermsOfService);
      sb.Append(",maxReferrals: ");
      sb.Append(this.maxReferrals);
      sb.Append(",referralCount: ");
      sb.Append(this.referralCount);
      sb.Append(",refererCode: ");
      sb.Append(this.refererCode);
      sb.Append(",sentEmailDate: ");
      sb.Append(this.sentEmailDate);
      sb.Append(",sentEmailCount: ");
      sb.Append(this.sentEmailCount);
      sb.Append(",dailyEmailLimit: ");
      sb.Append(this.dailyEmailLimit);
      sb.Append(",emailOptOutDate: ");
      sb.Append(this.emailOptOutDate);
      sb.Append(",partnerEmailOptInDate: ");
      sb.Append(this.partnerEmailOptInDate);
      sb.Append(",preferredLanguage: ");
      sb.Append(this.preferredLanguage);
      sb.Append(",preferredCountry: ");
      sb.Append(this.preferredCountry);
      sb.Append(",clipFullPage: ");
      sb.Append(this.clipFullPage);
      sb.Append(",twitterUserName: ");
      sb.Append(this.twitterUserName);
      sb.Append(",twitterId: ");
      sb.Append(this.twitterId);
      sb.Append(")");
      return sb.ToString();
    }

  }

}