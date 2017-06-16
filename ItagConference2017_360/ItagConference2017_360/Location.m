//
//  Location.m
//  ItagConference2017_360
//
//  Created by Joe Baldwin on 6/11/17.
//  Copyright © 2017 jbaldwin@hbs.net. All rights reserved.
//

#import "Location.h"

@implementation Location

@synthesize LocationId, BeaconId, Minor, Major, Name, Nickname;


- (NSString *) description
{
    NSString *descriptionString = [NSString stringWithFormat:@"LocationId:%@ BeaconId:%@, Minor:%@, Major:%@, Name:%@, Nickname:%@",
                                   LocationId,
                                   BeaconId,
                                   Minor,
                                   Major,
                                   Name,
                                   Nickname
                                   ];
    return descriptionString;
}

+ (Location*) FromData: (NSDictionary *) data
{
    Location *tempLocation = [[Location alloc] init];
    [tempLocation setLocationId:data[@"id"]];

    [tempLocation setNickname:data[@"nickname"]];
    [tempLocation setName:data[@"name"]];
    [tempLocation setBeaconId:data[@"beacon_guid"]];
    [tempLocation setMajor:data[@"major"]];
    [tempLocation setMinor:data[@"minor"]];
    return tempLocation;
}

@end
