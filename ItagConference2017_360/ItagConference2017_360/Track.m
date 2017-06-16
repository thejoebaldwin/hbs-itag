//
//  Track.m
//  ItagConference2017_360
//
//  Created by Joe Baldwin on 6/11/17.
//  Copyright © 2017 jbaldwin@hbs.net. All rights reserved.
//

#import "Track.h"

@implementation Track

@synthesize TrackId, Name, TrackDate;

- (NSString *) description
{
    NSString *descriptionString = [NSString stringWithFormat:@"TrackId:%@, Name:%@, TrackDate:%@",
                                   TrackId,
                                   Name,
                                   TrackDate
                                   ];
    return descriptionString;
}

+ (Track*) FromData: (NSDictionary *) data
{
    Track *tempTrack = [[Track alloc] init];
    NSDateFormatter *dateFormatter = [[NSDateFormatter alloc] init];
    [dateFormatter setDateFormat:@"yyyy-MM-dd'T'HH:mm:ss.SSS'Z'"];
    [tempTrack setTrackId:data[@"track_id"]];
    [tempTrack setName:data[@"name"]];
    NSString *tempDateString = data[@"track_date"];
    NSDate *tempDate =[dateFormatter dateFromString:tempDateString];
    [tempTrack setTrackDate:tempDate];
    return tempTrack;
}

@end
