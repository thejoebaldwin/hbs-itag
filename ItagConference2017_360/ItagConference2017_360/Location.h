//
//  Location.h
//  ItagConference2017_360
//
//  Created by Joe Baldwin on 6/11/17.
//  Copyright © 2017 jbaldwin@hbs.net. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Location : NSObject


@property (nonatomic) NSString *LocationId;
@property (nonatomic) NSString *BeaconId;
@property (nonatomic) NSNumber *Minor;
@property (nonatomic) NSNumber *Major;
@property (nonatomic) NSString *Name;
@property (nonatomic) NSString *Nickname;

+ (Location*) FromData: (NSDictionary *) data;

@end
