//
//  Store.m
//  ItagConference2017_360
//
//  Created by Joe Baldwin on 6/11/17.
//  Copyright © 2017 jbaldwin@hbs.net. All rights reserved.
//

#import "Store.h"

@implementation Store

@synthesize CurrentEvent, UserId,CheckLocation;

+ (id) allocWithZone:(NSZone *)zone
{
    return [self SharedInstance];
}

+(Store *) SharedInstance
{
    static Store *sharedInstance = nil;
    if (!sharedInstance) {
        sharedInstance = [[super allocWithZone:nil] init];
        
        [sharedInstance Initialize];
        sharedInstance.CheckLocation = true;
        
    }
    return sharedInstance;
}

- (NSArray *) Tracks
{
    return _arrTracks;
}

- (NSArray *) FilteredEvents
{
    NSDate *now = [NSDate date];
    //NSLog(@"Now:%@", now );
    NSMutableArray *arrFiltered = [[NSMutableArray alloc] init];
    for (int i = 0; i < _arrEvents.count; i++)
    {
        Event *tempEvent = _arrEvents[i];
        if (tempEvent.EndDate > now && ![tempEvent ScheduleOnly])
        {
            [arrFiltered addObject:tempEvent];
        }
    }
    return [[NSArray alloc] initWithArray:arrFiltered];;
}

- (NSArray *) Events
{
   return [_arrEvents sortedArrayUsingSelector:@selector(compare:)];
}

- (NSArray *) Locations
{
    return _arrLocations;
}



-(void) Initialize
  {
      _BaseUrl = @"https://hbs-itag.azurewebsites.net/";
      _arrEvents = [[NSMutableArray alloc] init];
      _arrTracks = [[NSMutableArray alloc] init];
      _arrLocations = [[NSMutableArray alloc] init];
  }

-(void) NewUser: (NSString *) gender withAge: (NSString *) age withState: (NSString *) state withPositionTitle: (NSString *) positionTitle withDevice: (NSString *) device withBlock:(void(^)(void)) block
{
    completion = block;
    _operation = @"new_user";
    NSString* JSON = [[NSString alloc] initWithFormat: @"{ \"gender\":\"%@\", \"state\":\"%@\",\"position_title\":\"%@\",\"device\":\"%@\",\"age\":\"%@\"}}", gender, state,positionTitle,device, age];
    NSString *_PostUrl = [[NSString alloc] initWithFormat:@"%@%@/", _BaseUrl, @"users" ];
    [self PostDataWithUrl:_PostUrl withJSON:JSON withMethod:@"POST"];
}

-(void) NewUserComplete:(NSData *) data withResponse:(NSURLResponse*) response withDictionary: (NSDictionary*) json
{
    NSLog(@"Json Response:%@", json);
    //[self dismissController];
}

-(void) NewSession: (Event *) event withEntering:(Boolean) entering withBlock:(void(^)(void)) block
{
    completion = block;
    _operation = @"new_session";
    
    NSString *enteringString;
    if (entering)
    {
        enteringString = @"true";
    }
    else
    {
        enteringString = @"false";
    }
    
    NSString* JSON = [[NSString alloc] initWithFormat: @"{ \"user_id\":\"%@\", \"event_id\":\"%@\", \"entering\":\"%@\" }", UserId, [event EventId], enteringString];
    NSString *_PostUrl = [[NSString alloc] initWithFormat:@"%@%@/", _BaseUrl, @"sessions" ];
    [self PostDataWithUrl:_PostUrl withJSON:JSON withMethod:@"POST"];
}

-(void) NewSessionComplete:(NSData *) data withResponse:(NSURLResponse*) response withDictionary: (NSDictionary*) json
{
    NSLog(@"Json Response:%@", json);
    //[self dismissController];
}

-(void) GetLocations: (void(^)(void)) block
{
    completion = block;
    _operation = @"get_locations";
    NSString *_PostUrl = [[NSString alloc] initWithFormat:@"%@%@/", _BaseUrl, @"locations" ];
    [self PostDataWithUrl:_PostUrl withJSON:nil withMethod:@"GET"];
}

-(void) GetLocationsComplete:(NSData *) data withResponse:(NSURLResponse*) response withDictionary: (NSDictionary*) json{
    
    NSArray *arrLocations =  [json objectForKey:@"locations"];
    for (int i = 0; i < [arrLocations count]; i++)
    {
        Location *tempLocation = [Location FromData: arrLocations[i]];
        NSLog(@"%@", tempLocation);
        if (tempLocation != nil)
        {
            [_arrLocations addObject:[Location FromData: arrLocations[i]]];
        }
    }
}

-(void) GetTracks: (void(^)(void)) block
{
     completion = block;
    _operation = @"get_tracks";
    NSString *_PostUrl = [[NSString alloc] initWithFormat:@"%@%@/", _BaseUrl, @"tracks" ];
    [self PostDataWithUrl:_PostUrl withJSON:nil withMethod:@"GET"];
}


-(void) GetTracksComplete:(NSData *) data withResponse:(NSURLResponse*) response withDictionary: (NSDictionary*) json{
    
    NSArray *arrTracks =  [json objectForKey:@"tracks"];
    for (int i = 0; i < [arrTracks count]; i++)
    {
        [_arrTracks addObject:[Track FromData: arrTracks[i]]];
    }
}

-(void) GetEvents: (void(^)(void)) block
{
    completion = block;
    _operation = @"get_events";
    NSString *_PostUrl = [[NSString alloc] initWithFormat:@"%@%@/", _BaseUrl, @"events" ];
    [self PostDataWithUrl:_PostUrl withJSON:nil withMethod:@"GET"];
}

-(void) GetEventsComplete: (NSData *) data withResponse:(NSURLResponse*) response withDictionary: (NSDictionary*) json
{
    NSArray *arrEvents =  [json objectForKey:@"events"];
    for (int i = 0; i < [arrEvents count]; i++)
    {
        [_arrEvents addObject:[Event FromData: arrEvents[i]]];
    }
    
    

}






- (void) PostDataWithUrl:(NSString *) urlString withJSON: (NSString *) JSON withMethod: (NSString *) httpMethod
{
    // Create a new data container for the stuff that comes back from the service
    //_jsonData = [[NSMutableData alloc] init];
    NSLog(@"Posting:%@ to %@", JSON, urlString);
    
    NSURL *url = [NSURL URLWithString: urlString];

    NSMutableURLRequest *request = [NSMutableURLRequest requestWithURL:url];
    
    NSData* postData;
    
    if (JSON != nil)
    {
        postData =[JSON dataUsingEncoding:NSUTF8StringEncoding];
    }
    
  
    [request setHTTPMethod:httpMethod];
    
    NSURLSessionConfiguration *config = [NSURLSessionConfiguration defaultSessionConfiguration];
    NSURLSession *session = [NSURLSession sessionWithConfiguration:config delegate:self delegateQueue:Nil];
    
    if ([httpMethod isEqualToString:@"GET"])
    {
    
        
        NSURLSessionDataTask *dataTask = [session dataTaskWithURL:url                                                  completionHandler:^(NSData *data, NSURLResponse *response, NSError *error) {
            
                if (data != nil)
                   {
                       NSDictionary *json = [NSJSONSerialization JSONObjectWithData:data options:kNilOptions error:nil];
                       if ([_operation isEqualToString:@"get_tracks"])
                       {
                           [self GetTracksComplete: data withResponse:response withDictionary:json];
                           
                           
                       }
                       else if ([_operation isEqualToString:@"get_events"])
                       {
                           
                           [self GetEventsComplete:data withResponse:response withDictionary:json];
                           
                       }
                       else if ([_operation isEqualToString:@"get_locations"])
                       {
                           
                           [self GetLocationsComplete:data withResponse:response withDictionary:json];
                           
                       }
                       
                       completion();
                           
                   }
            else
            {
                
            }
            
                                                       }];
        [dataTask resume];
    }
    else
    {
    
    NSURLSessionUploadTask *uploadTask = [session uploadTaskWithRequest:request
                                                               fromData:postData completionHandler:^(NSData *data,NSURLResponse *response,NSError *error) {
                                                                   // Handle response here
                                                                   
                                                                   if (data != nil)
                                                                   {
                                                                       NSDictionary *json = [NSJSONSerialization JSONObjectWithData:data options:kNilOptions error:nil];
                                                                     if ([_operation isEqualToString:@"new_user"])
                                                                       {
                                                                            [self NewUserComplete: data withResponse:response withDictionary:json];
                                                                       }
                                                                       else if ([_operation isEqualToString:@"new_session"])
                                                                       {
                                                                            [self NewSessionComplete: data withResponse:response withDictionary:json];
                                                                       }
                                                                       completion();
                                                                   }
                                                                   
                                                               }];
    
    
    
    // 5
    [uploadTask resume];
}
    
}

-(Event *) ProximityEvent: (NSString *) BeaconNickname
{
    //get location id from minor and major
    NSString *locationId = nil;
   
    Event *event = nil;
    if (BeaconNickname != nil)
    {
    for (int i = 0; i < [[[Store SharedInstance] Locations] count]; i++)
    {
        Location *tempLocation = [[Store SharedInstance] Locations][i];
        if ([tempLocation.Nickname isEqualToString:BeaconNickname])
        {
            locationId = tempLocation.LocationId;
            for (int i = 0; i < [[[Store SharedInstance] Events] count]; i++)
            {
                Event *tempEvent =[[Store SharedInstance] Events][i];
                if (tempEvent.LocationId != nil)
                {
                    if ([tempEvent.LocationId isEqualToString:locationId])
                    {
                        NSDate *now = [NSDate date];
                        
                        if ([self isBetweenDate: now withBeginDate: tempEvent.StartDate withEndDate: tempEvent.EndDate])
                        {
                            event = tempEvent;
                            break;
                        }
                    }
                }
            }
            if (event != nil)
            {
                break;
            }

            
        }
    }
    }
    
    
    
    return event;

}

- (BOOL) isBetweenDate:(NSDate*)betweenDate withBeginDate: (NSDate*)beginDate withEndDate:(NSDate*)endDate
{
    if ([betweenDate compare:beginDate] == NSOrderedAscending)
        return NO;
    
    if ([betweenDate compare:endDate] == NSOrderedDescending)
        return NO;
    
    return YES;
}

-(Event *) ProximityEvent: (NSNumber *) minor withMajor: (NSNumber *) major
{
    //get location id from minor and major
    NSString *locationId = nil;
     Event *event = nil;
       NSDate *now = [NSDate date];
    for (int i = 0; i < [[[Store SharedInstance] Locations] count]; i++)
    {
        Location *tempLocation = [[Store SharedInstance] Locations][i];
        if (tempLocation.Minor.intValue == minor.intValue && tempLocation.Major.intValue == major.intValue)
        {
            locationId = tempLocation.LocationId;
            for (int i = 0; i < [[[Store SharedInstance] Events] count]; i++)
            {
                Event *tempEvent =[[Store SharedInstance] Events][i];
                if (tempEvent.LocationId != nil)
                {
                    if ([tempEvent.LocationId isEqualToString:locationId])
                    {
                        //its a match, check if it's going on now
                        
                        if ([self isBetweenDate: now withBeginDate: tempEvent.StartDate withEndDate: tempEvent.EndDate])
                        {
                            event = tempEvent;
                            break;
                        }
                    }
                }
            }
            if (event != nil)
            {
                break;
            }

        }
    }
    
   
    
        //get event id from current time and location id
        //for now just get event id matched to location id
    
        
    
    
    return event;
}


@end
