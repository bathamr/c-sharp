﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PubnubApi
{
	public class Pubnub
	{
		PubnubWin pubnub;

		#region "PubNub API Channel Methods"

		public void Subscribe<T>(string channel, Action<Message<T>> subscribeCallback, Action<ConnectOrDisconnectAck> connectCallback, Action<ConnectOrDisconnectAck> disconnectCallback, Action<PubnubClientError> errorCallback)
		{
			if (string.IsNullOrEmpty(channel) || channel.Trim().Length <= 0)
			{
				throw new ArgumentException("Channel should be provided.");
			}
			pubnub.Subscribe<T>(channel, "", subscribeCallback, connectCallback, disconnectCallback, null, errorCallback);
		}

		public void Subscribe<T>(string channel, Action<Message<T>> subscribeCallback, Action<ConnectOrDisconnectAck> connectCallback, Action<ConnectOrDisconnectAck> disconnectCallback, Action<PresenceAck> wildcardPresenceCallback, Action<PubnubClientError> errorCallback)
		{
			if (string.IsNullOrEmpty(channel) || channel.Trim().Length <= 0)
			{
				throw new ArgumentException("Channel should be provided.");
			}
			pubnub.Subscribe<T>(channel, "", subscribeCallback, connectCallback, disconnectCallback, wildcardPresenceCallback, errorCallback);
		}

		public void Subscribe<T>(string channel, string channelGroup, Action<Message<T>> subscribeCallback, Action<ConnectOrDisconnectAck> connectCallback, Action<ConnectOrDisconnectAck> disconnectCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.Subscribe<T>(channel, channelGroup, subscribeCallback, connectCallback, disconnectCallback, null, errorCallback);
		}

		public void Subscribe<T>(string channel, string channelGroup, Action<Message<T>> subscribeCallback, Action<ConnectOrDisconnectAck> connectCallback, Action<ConnectOrDisconnectAck> disconnectCallback, Action<PresenceAck> wildcardPresenceCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.Subscribe<T>(channel, channelGroup, subscribeCallback, connectCallback, disconnectCallback, wildcardPresenceCallback, errorCallback);
		}

		public bool Publish(string channel, object message, Action<PublishAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.Publish(channel, message, true, "", userCallback, errorCallback);
		}

        public bool Publish(string channel, object message, bool storeInHistory, string jsonUserMetaData, Action<PublishAck> userCallback, Action<PubnubClientError> errorCallback)
		{
            return pubnub.Publish(channel, message, storeInHistory, jsonUserMetaData, userCallback, errorCallback);
		}

		public void Presence(string channel, Action<PresenceAck> presenceCallback, Action<ConnectOrDisconnectAck> connectCallback, Action<ConnectOrDisconnectAck> disconnectCallback, Action<PubnubClientError> errorCallback)
		{
			if (string.IsNullOrEmpty(channel) || channel.Trim().Length <= 0)
			{
				throw new ArgumentException("Channel should be provided.");
			}

			pubnub.Presence(channel, "", presenceCallback, connectCallback, disconnectCallback, errorCallback);
		}

		public void Presence(string channel, string channelGroup, Action<PresenceAck> presenceCallback, Action<ConnectOrDisconnectAck> connectCallback, Action<ConnectOrDisconnectAck> disconnectCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.Presence(channel, channelGroup, presenceCallback, connectCallback, disconnectCallback, errorCallback);
		}

		public bool DetailedHistory(string channel, long start, long end, int count, bool reverse, bool includeToken, Action<DetailedHistoryAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.DetailedHistory(channel, start, end, count, reverse, includeToken, userCallback, errorCallback);
		}

		public bool DetailedHistory(string channel, long start, bool includeToken, Action<DetailedHistoryAck> userCallback, Action<PubnubClientError> errorCallback, bool reverse)
		{
			return pubnub.DetailedHistory(channel, start, -1, -1, reverse, includeToken, userCallback, errorCallback);
		}

		public bool DetailedHistory(string channel, int count, bool includeToken, Action<DetailedHistoryAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.DetailedHistory(channel, -1, -1, count, false, includeToken, userCallback, errorCallback);
		}

		public bool HereNow(string[] channels, Action<HereNowAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.HereNow(channels, null, true, false, userCallback, errorCallback);
		}
		public bool HereNow(string[] channels, string[] channelGroups, Action<HereNowAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.HereNow(channels, channelGroups, true, false, userCallback, errorCallback);
		}

		public bool HereNow(string[] channels, bool showUUIDList, bool includeUserState, Action<HereNowAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.HereNow(channels, null, showUUIDList, includeUserState, userCallback, errorCallback);
		}
		public bool HereNow(string[] channels, string[] channelGroups, bool showUUIDList, bool includeUserState, Action<HereNowAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.HereNow(channels, channelGroups, showUUIDList, includeUserState, userCallback, errorCallback);
		}

		public bool GlobalHereNow(bool showUUIDList, bool includeUserState, Action<GlobalHereNowAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.GlobalHereNow(showUUIDList, includeUserState, userCallback, errorCallback);
		}

		public void WhereNow(string uuid, Action<WhereNowAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.WhereNow(uuid, userCallback, errorCallback);
		}

		public void Unsubscribe<T>(string channel, string channelGroup, Action<PubnubClientError> errorCallback)
		{
			pubnub.Unsubscribe<T>(channel, channelGroup, errorCallback);
		}

		public void Unsubscribe<T>(string channel, Action<PubnubClientError> errorCallback)
		{
			if (string.IsNullOrEmpty(channel) || channel.Trim().Length <= 0)
			{
				throw new ArgumentException("Channel should be provided.");
			}
			pubnub.Unsubscribe<T>(channel, null, errorCallback);
		}

		public void PresenceUnsubscribe(string channel, string channelGroup, Action<ConnectOrDisconnectAck> connectCallback, Action<ConnectOrDisconnectAck> disconnectCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.PresenceUnsubscribe(channel, channelGroup, disconnectCallback, errorCallback);
		}

		public void PresenceUnsubscribe(string channel, Action<ConnectOrDisconnectAck> connectCallback, Action<ConnectOrDisconnectAck> disconnectCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.PresenceUnsubscribe(channel, "", disconnectCallback, errorCallback);
		}

		public bool Time(Action<long> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.Time(userCallback, errorCallback);
		}

		public void AuditAccess(string channel, string authenticationKey, Action<AuditAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.AuditAccess<AuditAck>(channel, authenticationKey, userCallback, errorCallback);
		}

		public void AuditAccess(string channel, Action<AuditAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.AuditAccess<AuditAck>(channel, userCallback, errorCallback);
		}

		public void AuditAccess(Action<AuditAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.AuditAccess<AuditAck>(userCallback, errorCallback);
		}

		public void AuditPresenceAccess(string channel, Action<AuditAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.AuditPresenceAccess<AuditAck>(channel, userCallback, errorCallback);
		}

		public void AuditPresenceAccess(string channel, string authenticationKey, Action<AuditAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.AuditPresenceAccess<AuditAck>(channel, authenticationKey, userCallback, errorCallback);
		}

		public bool GrantAccess(string channel, bool read, bool write, int ttl, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.GrantAccess<GrantAck>(channel, read, write, ttl, userCallback, errorCallback);
		}

		public bool GrantAccess(string channel, bool read, bool write, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.GrantAccess<GrantAck>(channel, read, write, userCallback, errorCallback);
		}

		public bool GrantAccess(string channel, string authenticationKey, bool read, bool write, int ttl, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.GrantAccess<GrantAck>(channel, authenticationKey, read, write, ttl, userCallback, errorCallback);
		}

		public bool GrantAccess(string channel, string authenticationKey, bool read, bool write, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.GrantAccess<GrantAck>(channel, authenticationKey, read, write, userCallback, errorCallback);
		}


		public bool GrantPresenceAccess(string channel, bool read, bool write, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.GrantPresenceAccess<GrantAck>(channel, read, write, userCallback, errorCallback);
		}

		public bool GrantPresenceAccess(string channel, bool read, bool write, int ttl, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.GrantPresenceAccess<GrantAck>(channel, read, write, ttl, userCallback, errorCallback);
		}

		public bool GrantPresenceAccess(string channel, string authenticationKey, bool read, bool write, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.GrantPresenceAccess<GrantAck>(channel, authenticationKey, read, write, userCallback, errorCallback);
		}

		public bool GrantPresenceAccess(string channel, string authenticationKey, bool read, bool write, int ttl, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.GrantPresenceAccess<GrantAck>(channel, authenticationKey, read, write, ttl, userCallback, errorCallback);
		}

		public void ChannelGroupAuditAccess(string channelGroup, string authenticationKey, Action<AuditAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.ChannelGroupAuditAccess<AuditAck>(channelGroup, authenticationKey, userCallback, errorCallback);
		}

		public void ChannelGroupAuditAccess(string channelGroup, Action<AuditAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.ChannelGroupAuditAccess<AuditAck>(channelGroup, userCallback, errorCallback);
		}

		public void ChannelGroupAuditAccess(Action<AuditAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.ChannelGroupAuditAccess<AuditAck>(userCallback, errorCallback);
		}

		public void ChannelGroupAuditPresenceAccess(string channelGroup, Action<AuditAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.ChannelGroupAuditPresenceAccess<AuditAck>(channelGroup, userCallback, errorCallback);
		}

		public void ChannelGroupAuditPresenceAccess(string channelGroup, string authenticationKey, Action<AuditAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.ChannelGroupAuditPresenceAccess<AuditAck>(channelGroup, authenticationKey, userCallback, errorCallback);
		}

		public bool ChannelGroupGrantAccess(string channelGroup, bool read, bool manage, int ttl, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.ChannelGroupGrantAccess<GrantAck>(channelGroup, read, false, manage, ttl, userCallback, errorCallback);
		}

		public bool ChannelGroupGrantAccess(string channelGroup, bool read, bool manage, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.ChannelGroupGrantAccess<GrantAck>(channelGroup, read, false, manage, userCallback, errorCallback);
		}

		public bool ChannelGroupGrantAccess(string channelGroup, string authenticationKey, bool read, bool manage, int ttl, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.ChannelGroupGrantAccess<GrantAck>(channelGroup, authenticationKey, read, false, manage, ttl, userCallback, errorCallback);
		}

		public bool ChannelGroupGrantAccess(string channelGroup, string authenticationKey, bool read, bool manage, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.ChannelGroupGrantAccess<GrantAck>(channelGroup, authenticationKey, read, false, manage, userCallback, errorCallback);
		}


		public bool ChannelGroupGrantPresenceAccess(string channelGroup, bool read, bool manage, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.ChannelGroupGrantPresenceAccess<GrantAck>(channelGroup, read, false, manage, userCallback, errorCallback);
		}

		public bool ChannelGroupGrantPresenceAccess(string channelGroup, bool read, bool manage, int ttl, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.ChannelGroupGrantPresenceAccess<GrantAck>(channelGroup, read, false, manage, ttl, userCallback, errorCallback);
		}

		public bool ChannelGroupGrantPresenceAccess(string channelGroup, string authenticationKey, bool read, bool manage, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.ChannelGroupGrantPresenceAccess<GrantAck>(channelGroup, authenticationKey, read, false, manage, userCallback, errorCallback);
		}

		public bool ChannelGroupGrantPresenceAccess(string channelGroup, string authenticationKey, bool read, bool manage, int ttl, Action<GrantAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			return pubnub.ChannelGroupGrantPresenceAccess<GrantAck>(channelGroup, authenticationKey, read, false, manage, ttl, userCallback, errorCallback);
		}


		public void SetUserState(string channel, string channelGroup, string uuid, string jsonUserState, Action<SetUserStateAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.SetUserState(channel, channelGroup, uuid, jsonUserState, userCallback, errorCallback);
		}

		public void SetUserState(string channel, string channelGroup, string jsonUserState, Action<SetUserStateAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.SetUserState(channel, channelGroup, "", jsonUserState, userCallback, errorCallback);
		}

		public void SetUserState(string channel, string jsonUserState, Action<SetUserStateAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.SetUserState(channel,"", jsonUserState, userCallback, errorCallback);
		}

		public void SetUserState(string channel, string channelGroup, string uuid, System.Collections.Generic.KeyValuePair<string, object> keyValuePair, Action<SetUserStateAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.SetUserState(channel, channelGroup, uuid, keyValuePair, userCallback, errorCallback);
		}

		public void SetUserState(string channel, string channelGroup, System.Collections.Generic.KeyValuePair<string, object> keyValuePair, Action<SetUserStateAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.SetUserState(channel, channelGroup, "", keyValuePair, userCallback, errorCallback);
		}

		public void SetUserState(string channel, System.Collections.Generic.KeyValuePair<string, object> keyValuePair, Action<SetUserStateAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.SetUserState(channel, "", keyValuePair, userCallback, errorCallback);
		}

		public void GetUserState(string channel, string channelGroup, Action<GetUserStateAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.GetUserState(channel, channelGroup, "", userCallback, errorCallback);
		}

		public void GetUserState(string channel, Action<GetUserStateAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.GetUserState(channel, "", userCallback, errorCallback);
		}

		public void GetUserState(string channel, string channelGroup, string uuid, Action<GetUserStateAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.GetUserState(channel, channelGroup, uuid, userCallback, errorCallback);
		}

		public void RegisterDeviceForPush<T>(string channel, PushTypeService pushType, string pushToken, Action<T> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.RegisterDeviceForPush<T>(channel, pushType, pushToken, userCallback, errorCallback);
		}

		public void UnregisterDeviceForPush<T>(PushTypeService pushType, string pushToken, Action<T> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.UnregisterDeviceForPush<T>(pushType, pushToken, userCallback, errorCallback);
		}

		public void RemoveChannelForDevicePush<T>(string channel, PushTypeService pushType, string pushToken, Action<T> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.RemoveChannelForDevicePush<T>(channel, pushType, pushToken, userCallback, errorCallback);
		}
		public void RemoveChannelForDevicePush(string channel, PushTypeService pushType, string pushToken, Action<object> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.RemoveChannelForDevicePush<object>(channel, pushType, pushToken, userCallback, errorCallback);
		}

		public void GetChannelsForDevicePush<T>(PushTypeService pushType, string pushToken, Action<T> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.GetChannelsForDevicePush<T>(pushType, pushToken, userCallback, errorCallback);
		}
		#endregion

		#region "PubNub API Channel Group Methods"
		public void AddChannelsToChannelGroup(string[] channels, string groupName, Action<AddChannelToChannelGroupAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.AddChannelsToChannelGroup(channels, groupName, userCallback, errorCallback);
		}

		public void AddChannelsToChannelGroup(string[] channels, string nameSpace, string groupName, Action<AddChannelToChannelGroupAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.AddChannelsToChannelGroup(channels, nameSpace, groupName, userCallback, errorCallback);
		}

		public void RemoveChannelsFromChannelGroup(string[] channels, string nameSpace, string groupName, Action<RemoveChannelFromChannelGroupAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.RemoveChannelsFromChannelGroup(channels, nameSpace, groupName, userCallback, errorCallback);
		}

		public void RemoveChannelsFromChannelGroup(string[] channels, string groupName, Action<RemoveChannelFromChannelGroupAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.RemoveChannelsFromChannelGroup(channels, groupName, userCallback, errorCallback);
		}

		public void RemoveChannelGroup(string nameSpace, string groupName, Action<RemoveChannelGroupAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.RemoveChannelGroup(nameSpace, groupName, userCallback, errorCallback);
		}

		public void RemoveChannelGroupNameSpace(string nameSpace, Action<RemoveNamespaceAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.RemoveChannelGroupNameSpace(nameSpace, userCallback, errorCallback);
		}

		public void GetChannelsForChannelGroup(string nameSpace, string groupName, Action<GetChannelGroupChannelsAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.GetChannelsForChannelGroup(nameSpace, groupName, userCallback, errorCallback);
		}

		public void GetChannelsForChannelGroup(string groupName, Action<GetChannelGroupChannelsAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.GetChannelsForChannelGroup(groupName, userCallback, errorCallback);
		}

		public void GetAllChannelGroups(string nameSpace, Action<GetAllChannelGroupsAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.GetAllChannelGroups(nameSpace, userCallback, errorCallback);
		}

		public void GetAllChannelGroups(Action<GetAllChannelGroupsAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.GetAllChannelGroups(userCallback, errorCallback);
		}

		public void GetAllChannelGroupNamespaces(Action<GetAllNamespacesAck> userCallback, Action<PubnubClientError> errorCallback)
		{
			pubnub.GetAllChannelGroupNamespaces(userCallback, errorCallback);
		}

		#endregion

		#region "PubNub API Other Methods"
		public void TerminateCurrentSubscriberRequest()
		{
			pubnub.TerminateCurrentSubscriberRequest();
		}

		public void EnableSimulateNetworkFailForTestingOnly()
		{
			pubnub.EnableSimulateNetworkFailForTestingOnly();
		}

		public void DisableSimulateNetworkFailForTestingOnly()
		{
			pubnub.DisableSimulateNetworkFailForTestingOnly();
		}

		public void EnableMachineSleepModeForTestingOnly()
		{
			pubnub.EnableMachineSleepModeForTestingOnly();
		}

		public void DisableMachineSleepModeForTestingOnly()
		{
			pubnub.DisableMachineSleepModeForTestingOnly();
		}

		public void EndPendingRequests()
		{
			pubnub.EndPendingRequests();
		}

		public Guid GenerateGuid()
		{
			return pubnub.GenerateGuid();
		}

		public void ChangeUUID(string newUUID)
		{
			pubnub.ChangeUUID(newUUID);
		}

		public static long TranslateDateTimeToPubnubUnixNanoSeconds(DateTime dotNetUTCDateTime)
		{
			return PubnubWin.TranslateDateTimeToPubnubUnixNanoSeconds(dotNetUTCDateTime);
		}

		public static DateTime TranslatePubnubUnixNanoSecondsToDateTime(long unixNanoSecondTime)
		{
			return PubnubWin.TranslatePubnubUnixNanoSecondsToDateTime(unixNanoSecondTime);
		}

		public static DateTime TranslatePubnubUnixNanoSecondsToDateTime(string unixNanoSecondTime)
		{
			return PubnubWin.TranslatePubnubUnixNanoSecondsToDateTime(unixNanoSecondTime);
		}

        public void SetPubnubLog(IPubnubLog pubnubLog) 
         { 
             pubnub.PubnubLog = pubnubLog; 
         } 

        public void SetInternalLogLevel(LoggingMethod.Level logLevel)
        {
            pubnub.PubnubLogLevel = logLevel;
        }

        public void SetErrorFilterLevel(PubnubErrorFilter.Level errorLevel)
        {
            pubnub.PubnubErrorLevel = errorLevel;
        }  

		#endregion

		#region "Properties"
		public string AuthenticationKey {
			get {return pubnub.AuthenticationKey;}
			set {pubnub.AuthenticationKey = value;}
		}

		public int LocalClientHeartbeatInterval {
			get {return pubnub.LocalClientHeartbeatInterval;}
			set {pubnub.LocalClientHeartbeatInterval = value;}
		}

		public int NetworkCheckRetryInterval {
			get {return pubnub.NetworkCheckRetryInterval;}
			set {pubnub.NetworkCheckRetryInterval = value;}
		}

		public int NetworkCheckMaxRetries {
			get {return pubnub.NetworkCheckMaxRetries;}
			set {pubnub.NetworkCheckMaxRetries = value;}
		}

		public int NonSubscribeTimeout {
			get {return pubnub.NonSubscribeTimeout;}
			set {pubnub.NonSubscribeTimeout = value;}
		}

		public int SubscribeTimeout {
			get {return pubnub.SubscribeTimeout;}
			set {pubnub.SubscribeTimeout = value;}
		}

		public bool EnableResumeOnReconnect {
			get {return pubnub.EnableResumeOnReconnect;}
			set {pubnub.EnableResumeOnReconnect = value;}
		}

		public string SessionUUID {
			get {return pubnub.SessionUUID;}
			set {pubnub.SessionUUID = value;}
		}

		public string Origin {
			get {return pubnub.Origin;}
			set {pubnub.Origin = value;}
		}

		public int PresenceHeartbeat
		{
			get
			{
				return pubnub.PresenceHeartbeat;
			}
			set
			{
				pubnub.PresenceHeartbeat = value;
			}
		}

		public int PresenceHeartbeatInterval
		{
			get
			{
				return pubnub.PresenceHeartbeatInterval;
			}
			set
			{
				pubnub.PresenceHeartbeatInterval = value;
			}
		}

		public IPubnubUnitTest PubnubUnitTest
		{
			get
			{
				return pubnub.PubnubUnitTest;
			}
			set
			{
				pubnub.PubnubUnitTest = value;
			}
		}

		public bool EnableJsonEncodingForPublish
		{
			get
			{
				return pubnub.EnableJsonEncodingForPublish;
			}
			set
			{
				pubnub.EnableJsonEncodingForPublish = value;
			}
		}

		public PubnubProxy Proxy
		{
			get
			{
				return pubnub.Proxy;
			}
			set
			{
				pubnub.Proxy = value;
			}
		}

		public IJsonPluggableLibrary JsonPluggableLibrary
		{
			get
			{
				return pubnub.JsonPluggableLibrary;
			}
			set
			{
				pubnub.JsonPluggableLibrary = value;
			}
		}

		public IPubnubSubscribeMessageType SubscribeMessageType
		{
			get
			{
				return pubnub.SubscribeMessageType;
			}
			set
			{
				pubnub.SubscribeMessageType = value;
			}
		}

		public bool EnableDebugForPushPublish
		{
			get
			{
				return pubnub.EnableDebugForPushPublish;
			}
			set
			{
				pubnub.EnableDebugForPushPublish = value;
			}
		}

		public Collection<Uri> PushRemoteImageDomainUri
		{
			get
			{
				return pubnub.PushRemoteImageDomainUri;
			}

			set
			{
				pubnub.PushRemoteImageDomainUri = value;
			}
		}

		public string PushServiceName
		{
			get
			{
				return pubnub.PushServiceName;
			}

			set
			{
				pubnub.PushServiceName = value;
			}
		}

        public bool AddPayloadToPublishResponse
        {
            get
            {
                return pubnub.AddPayloadToPublishResponse;
            }
            set
            {
                pubnub.AddPayloadToPublishResponse = value;
            }
        }
		#endregion

		#region "Constructors"

		public Pubnub(string publishKey, string subscribeKey, string secretKey, string cipherKey, bool sslOn)
		{
			pubnub = new PubnubWin (publishKey, subscribeKey, secretKey, cipherKey, sslOn);
		}

		public Pubnub(string publishKey, string subscribeKey, string secretKey)
		{
			pubnub = new PubnubWin (publishKey, subscribeKey, secretKey);
		}

		public Pubnub(string publishKey, string subscribeKey)
		{
			pubnub = new PubnubWin (publishKey, subscribeKey);
		}
		#endregion
	}
}