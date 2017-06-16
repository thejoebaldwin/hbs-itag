//
//  EventTableCell.h
//  ItagConference2017_360
//
//  Created by Joe Baldwin on 6/12/17.
//  Copyright © 2017 jbaldwin@hbs.net. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface EventTableCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UILabel *NameLabel;
@property (weak, nonatomic) IBOutlet UILabel *TimeLabel;


@property (nonatomic) NSString *name;
@property (nonatomic) NSString *time;

@end
