#!/bin/sh

export POST_URL=https://adopseback.inherently.xyz/api/multiplechoicequestion
export TEMPLATE_FILE=template-multiplechoice.json
export CONFIG_FILE=config-multiplechoice.yml
export ITER=1000
./gogenjson
