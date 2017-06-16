//
//  EventTableCell.m
//  ItagConference2017_360
//
//  Created by Joe Baldwin on 6/12/17.
//  Copyright © 2017 jbaldwin@hbs.net. All rights reserved.
//

#import "EventTableCell.h"

@implementation EventTableCell


@synthesize NameLabel, TimeLabel, name, time;


- (void)awakeFromNib {
    [super awakeFromNib];
    // Initialization code
    
    
    NameLabel.text = name;
    TimeLabel.text = time;
    
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
