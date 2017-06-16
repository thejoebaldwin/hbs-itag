//
//  Track.h
//  ItagConference2017_360
//
//  Created by Joe Baldwin on 6/11/17.
//  Copyright © 2017 jbaldwin@hbs.net. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Track : NSObject


@property (nonatomic) NSString *TrackId;
@property (nonatomic) NSString *Name;
@property (nonatomic) NSDate *TrackDate;

+ (Track*) FromData: (NSDictionary *) data;

@end
