//
//  Event.h
//  ItagConference2017_360
//
//  Created by Joe Baldwin on 6/11/17.
//  Copyright © 2017 jbaldwin@hbs.net. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Event : NSObject
{
    
}


@property (nonatomic) NSString *EventId;
@property (nonatomic) NSString *LocationId;
@property (nonatomic) NSDate *StartDate;
@property (nonatomic) NSDate *EndDate;
@property (nonatomic) NSString *Presenter;
@property (nonatomic) NSString *Summary;
@property (nonatomic) NSString *EventWebId;
@property (nonatomic) Boolean ScheduleOnly;
@property (nonatomic) NSString *Name;

+ (Event*) FromData: (NSDictionary *) data;

@end
