//
//  Store.h
//  ItagConference2017_360
//
//  Created by Joe Baldwin on 6/11/17.
//  Copyright © 2017 jbaldwin@hbs.net. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Track.h"
#import "Event.h"
#import "Location.h"


@interface Store : NSObject
{
    NSURLConnection *_Connection;
    NSMutableData *_jsonData;
    NSString * _rawResponse;
    NSString * _token;
    NSString * _operation;
    
    void (^completion)(void);
    NSString * _BaseUrl;
    
    NSMutableArray * _arrTracks;
    NSMutableArray * _arrLocations;
    NSMutableArray * _arrEvents;
   
}


-(void) Initialize;

@property (nonatomic) Event *CurrentEvent;
@property (nonatomic) NSString *UserId;
@property (nonatomic) Boolean CheckLocation;
@property (nonatomic) Boolean IsEventDetailVisible;

+(Store *) SharedInstance;
- (NSArray *) Tracks;
- (NSArray *) Locations;
- (NSArray *) Events;
- (NSArray *) FilteredEvents;

-(void) GetTracks: (void(^)(void)) block;
-(void) GetLocations: (void(^)(void)) block;
-(void) GetEvents: (void(^)(void)) block;
-(void) NewUser: (NSString *) gender withAge: (NSString *) age withState: (NSString *) state withPositionTitle: (NSString *) positionTitle withDevice: (NSString *) device withBlock:(void(^)(void)) block;

-(void) NewSession: (Event *) event withEntering:(Boolean) entering withBlock:(void(^)(void)) block;

-(Event *) ProximityEvent: (NSNumber *) minor withMajor: (NSNumber *) major;
-(Event *) ProximityEvent: (NSString *) BeaconNickname;
@end
