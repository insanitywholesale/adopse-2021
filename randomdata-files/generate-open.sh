#!/bin/sh

export POST_URL=https://adopseback.inherently.xyz/api/openquestion
export TEMPLATE_FILE=template-open.json
export CONFIG_FILE=config-open.yml
export ITER=1000
./gogenjson
