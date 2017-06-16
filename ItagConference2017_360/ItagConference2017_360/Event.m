//
//  Event.m
//  ItagConference2017_360
//
//  Created by Joe Baldwin on 6/11/17.
//  Copyright © 2017 jbaldwin@hbs.net. All rights reserved.
//

#import "Event.h"

@implementation Event

@synthesize EventId, LocationId, StartDate, EndDate, Presenter, Summary, EventWebId, Name,ScheduleOnly;

- (NSString *) description
{
    NSString *descriptionString = [NSString stringWithFormat:@"EventId:%@ LocationId:%@, StartDate:%@, EndDate:%@",
                                   EventId,
                                   LocationId,
                                   StartDate,
                                   EndDate
                                   ];
    return descriptionString;
}


+ (Event*) FromData: (NSDictionary *) data
{
    Event *tempEvent = [[Event alloc] init];
    NSDateFormatter *dateFormatter = [[NSDateFormatter alloc] init];
    [dateFormatter setDateFormat:@"yyyy-MM-dd'T'HH:mm:ss.SSS'Z'"];
    [tempEvent setEventId:data[@"event_id"]];
    [tempEvent setName:data[@"name"]];
    [tempEvent setLocationId:data[@"location_id"]];
    NSDate *startDateRaw = [dateFormatter dateFromString:[NSString stringWithFormat:@"%@", data[@"start_time"]]];
    NSDate *endDateRaw = [dateFormatter dateFromString:[NSString stringWithFormat:@"%@", data[@"end_time"]]];
    
    NSTimeInterval secondsInFiveHours = -5 * 60 * 60;
    
    
    NSDate *startDate = [startDateRaw dateByAddingTimeInterval:secondsInFiveHours];
    NSDate *endDate = [endDateRaw dateByAddingTimeInterval:secondsInFiveHours];
    
    [tempEvent setStartDate:startDate];
    [tempEvent setEndDate:endDate];
    [tempEvent setPresenter:data[@"presenter"]];
    [tempEvent setSummary:data[@"summary"]];
    [tempEvent setEventWebId:data[@"event_web_id"]];
    if ([data[@"schedule_only"] isEqualToString:@"true"])
    {
        [tempEvent setScheduleOnly:true];

    }
    else
    {
        [tempEvent setScheduleOnly:false];

    }
        return tempEvent;
}

- (NSComparisonResult)compare:(Event *)otherObject {
    return [self.StartDate compare:otherObject.StartDate];
}

@end
